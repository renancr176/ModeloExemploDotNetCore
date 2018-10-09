using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Extensao.Domain.Proposta;
using Extensao.Domain.Proposta.Commands.Outputs;
using Extensao.Domain.Proposta.Queries;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;
using MongoDB.Driver;

namespace Extensao.Infra.Data.Repositories
{
    public class TipoInscricaoRepository : ITipoInscricaoRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;
        private readonly MongoDBDataContext _mongoDb;

        public TipoInscricaoRepository(DataContext context, IUow uow, MongoDBDataContext mongoDb)
        {
            _context = context;
            _uow = uow;
            _mongoDb = mongoDb;
        }

        #region Select

        public IEnumerable<TipoInscricaoQuery> ObterTodosTipoInscricao()
        {
            return _context
                .Connection
                .Query<TipoInscricaoQuery>(
                    "dbo.spConsultaTipoInscricao",
                    commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<TipoInscricaoRascunhoQuery> ObterTodosRascunhosTipoInscricaoUsuario(string aliasUsuario)
        {
            var tipoInscricao = new List<TipoInscricaoRascunhoQuery>();
            try
            {
                var cursor = _mongoDb.Database.GetCollection<TipoInscricao>("TipoInscricao").Find(c => c.AliasUsuario == aliasUsuario).ToEnumerable();

                foreach (var obj in cursor)
                {
                    tipoInscricao.Add(new TipoInscricaoRascunhoQuery()
                    {
                        Id = obj.Id,
                        Descricao = obj.Descricao,
                        Status = obj.Status,
                        AliasUsuario = obj.AliasUsuario
                    });
                }
            }
            catch (Exception e)
            {
            }
            return tipoInscricao;
        }

        public TipoInscricaoQuery ObtemTipoInscricaoPorId(Guid idTipoInscricao)
        {
            return _context
                .Connection
                .Query<TipoInscricaoQuery>(
                    "dbo.spConsultaTipoInscricao",
                    new {IdTipoInscricao = idTipoInscricao},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        #endregion

        public CommandResult CadastrarTipoInscricao(TipoInscricao tipoInscricao)
        {
            try
            {
                _uow.BeginTransaction();
                _uow.GetConnection().Execute(
                    "dbo.spGravaTipoInscricao",
                    new
                    {
                        Id = tipoInscricao.Id,
                        Descricao = tipoInscricao.Descricao,
                        Status = tipoInscricao.Status,
                        AliasUsuario = tipoInscricao.AliasUsuario
                    },
                    _uow.GetTransaction(),
                    commandType: CommandType.StoredProcedure
                );

                _uow.Commit();
                return new CommandResult(true, "Cadastro realizado com sucesso.", null);
            }
            catch (Exception e)
            {
                _uow.Rollback();
                return new CommandResult(false, "Erro ao tentar realizar cadastro: "+e.Message, null);
            }
        }

        public CommandResult AlterarTipoInscricao(TipoInscricao tipoInscricao)
        {
            try
            {
                _uow.BeginTransaction();
                _uow.GetConnection().Execute(
                    "dbo.spAtualizaTipoInscricao",
                    new
                    {
                        Id = tipoInscricao.Id,
                        Descricao = tipoInscricao.Descricao,
                        Status = tipoInscricao.Status,
                        AliasUsuario = tipoInscricao.AliasUsuario
                    },
                    _uow.GetTransaction(),
                    commandType: CommandType.StoredProcedure
                );

                _uow.Commit();
                return new CommandResult(true, "Alteração realizada com sucesso.", null);
            }
            catch (Exception e)
            {
                _uow.Rollback();
                return new CommandResult(false, "Erro ao tentar realizar cadastro: "+e.Message, null);
            }
        }

        public CommandResult RascunhoTipoInscricao(TipoInscricao tipoInscricao)
        {
            try
            {

                var filter = Builders<TipoInscricao>.Filter.Eq(c => c.Id, tipoInscricao.Id);
                if (_mongoDb.Database.GetCollection<TipoInscricao>("TipoInscricao").Find(filter)
                        .CountDocuments() == 1)
                {
                    var result =_mongoDb.Database.GetCollection<TipoInscricao>("TipoInscricao")
                        .ReplaceOne(filter, tipoInscricao);
                }
                else
                {
                    _mongoDb.Database.GetCollection<TipoInscricao>("TipoInscricao").InsertOne(tipoInscricao);
                }
                
                return new CommandResult(true, "Rasculho salvo com sucesso.", tipoInscricao);
            }
            catch (Exception e)
            {
                return new CommandResult(false, "Falha ao tentar salvar o rasculho: "+e.Message, null);
            }
        }


        public bool DescricaoExists(string descricao)
        {
            return
                _context
                    .Connection
                    .Query<TipoInscricaoQuery>(
                        "dbo.spConsultaTipoInscricao",
                        new { Descricao = descricao },
                        commandType: CommandType.StoredProcedure)
                    .Any();
        }
    }
}
