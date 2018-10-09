using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Extensao.Domain.Proposta.Queries;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;

namespace Extensao.Infra.Data.Repositories
{
    public class TipoAtividadeRepository : ITipoAtividadeRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;
        private readonly MongoDBDataContext _mongoDb;

        public TipoAtividadeRepository(DataContext context, IUow uow, MongoDBDataContext mongoDb)
        {
            _context = context;
            _uow = uow;
            _mongoDb = mongoDb;
        }

        public TipoAtividadeQuery ObtemTipoAtividadePorId(Guid idTipoAtividade)
        {
            return _context
                .Connection
                .Query<TipoAtividadeQuery>(
                    "dbo.spConsultaTipoAtividade",
                    new
                    {
                        Ativo = 1,
                        IdTipoAtividade = idTipoAtividade
                    },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<TipoAtividadeQuery> ObterTodosTipoAtividade()
        {
            return _context
                .Connection
                .Query<TipoAtividadeQuery>(
                    "dbo.spConsultaTipoAtividade",
                    new
                    {
                        Ativo = 1
                    },
                    commandType: CommandType.StoredProcedure);
        }
    }
}
