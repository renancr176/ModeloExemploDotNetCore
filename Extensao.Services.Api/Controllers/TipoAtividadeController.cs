using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extensao.Domain.Proposta.Handlers;
using Extensao.Domain.Proposta.Queries;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Extensao.Services.Api.Controllers
{
    public class TipoAtividadeController : BaseController
    {
        private readonly ITipoAtividadeRepository _tipoAtividadeRepository;


        public TipoAtividadeController(IUow uow, ITipoAtividadeRepository tipoAtividadeRepository) : base(uow)
        {
            _tipoAtividadeRepository = tipoAtividadeRepository;
        }

        /// <summary>
        ///  Retorna o registro do tipo de atividade
        /// </summary>
        /// <remarks>Retorna o registro do tipo de atividade</remarks>
        /// <param name="id">ID Tipo Atividade</param>
        /// <returns>TipoAtividadeQuery</returns>
        [HttpGet]
        [Route("v1/tipo/atividade/{id:Guid}")]
        public TipoAtividadeQuery ObtemTipoAtividadePorId(Guid id) => _tipoAtividadeRepository.ObtemTipoAtividadePorId(id);

        /// <summary>
        ///  Retorna a lista de tipo de atividade
        /// </summary>
        /// <remarks>Retorna a lista de tipo de atividade</remarks>        
        /// <returns>TipoAtividadeQuery</returns>
        [HttpGet]
        [Route("v1/tipo/atividade")]
        public IEnumerable<TipoAtividadeQuery> ObterTodosTipoAtividade() => _tipoAtividadeRepository.ObterTodosTipoAtividade();
    }
}
