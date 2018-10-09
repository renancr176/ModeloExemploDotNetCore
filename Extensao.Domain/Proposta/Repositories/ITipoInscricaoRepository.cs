using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Proposta.Commands.Outputs;
using Extensao.Domain.Proposta.Queries;

namespace Extensao.Domain.Proposta.Repositories
{
   public interface ITipoInscricaoRepository
    {
        #region Select
        TipoInscricaoQuery ObtemTipoInscricaoPorId(Guid idTipoInscricao);
        IEnumerable<TipoInscricaoQuery> ObterTodosTipoInscricao();
        IEnumerable<TipoInscricaoRascunhoQuery> ObterTodosRascunhosTipoInscricaoUsuario(string aliasUsuario); 
        #endregion

        CommandResult CadastrarTipoInscricao(TipoInscricao tipoInscricao);
        CommandResult AlterarTipoInscricao(TipoInscricao tipoInscricao);
        CommandResult RascunhoTipoInscricao(TipoInscricao tipoInscricao);

        bool DescricaoExists(string descricao);
    }
}
