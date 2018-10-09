using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Proposta.Commands.Outputs;
using Extensao.Domain.Proposta.Queries;

namespace Extensao.Domain.Proposta.Repositories
{
    public interface ITipoAtividadeRepository
    {
        #region Select
        TipoAtividadeQuery ObtemTipoAtividadePorId(Guid idTipoAtividade);
        IEnumerable<TipoAtividadeQuery> ObterTodosTipoAtividade();
        #endregion

    }
}
