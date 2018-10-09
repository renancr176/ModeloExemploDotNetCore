using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Extensao.Domain.Proposta.Commands.Inputs;
using Extensao.Domain.Proposta.Handlers;
using Extensao.Domain.Proposta.Queries;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace Extensao.Services.Api.Controllers
{
    public class TipoInscricaoController : BaseController
    {

        private readonly ITipoInscricaoRepository _tipoInscricaoRepository;
        private readonly TipoInscricaoCommandHandler _handler;


        public TipoInscricaoController(IUow uow, ITipoInscricaoRepository tipoInscricaoRepository, TipoInscricaoCommandHandler handler) : base(uow)
        {
            _tipoInscricaoRepository = tipoInscricaoRepository;
            _handler = handler;
        }

        /// <summary>
        ///  Retorna descrição do tipo de inscrição
        /// </summary>
        /// <remarks>Retorna uma lista com a descrição e Id dos tipos de incrição</remarks>
        /// <param name="id">ID Tipo Inscrição</param>
        /// <returns>TipoInscricaoQuery</returns>
        [HttpGet]
        [Route("v1/tipo/inscricao/{id:Guid}")]
        public TipoInscricaoQuery ObtemTipoInscricaoPorId(Guid id) => _tipoInscricaoRepository.ObtemTipoInscricaoPorId(id);

        /// <summary>
        ///  Retorna descrição do tipo de inscrição
        /// </summary>
        /// <remarks>Retorna uma lista com a descrição e Id dos tipos de incrição</remarks>        
        /// <returns>TipoInscricaoQuery</returns>
        [HttpGet]
        [Route("v1/tipo/inscricao")]
        public IEnumerable<TipoInscricaoQuery> ObterTodosTipoInscricao() => _tipoInscricaoRepository.ObterTodosTipoInscricao();

        /// <summary>
        ///  Retorna os rascunhos do tipo de inscrição de um usuário
        /// </summary>
        /// <remarks>Retorna os rascunhos do tipo de inscrição de um usuário</remarks>
        /// <param name="aliasUsuario">Alias do Usuário</param>
        /// <returns>TipoInscricaoQuery</returns>
        [HttpGet]
        [Route("v1/rascunho/tipo/inscricao/{aliasUsuario}")]
        public IEnumerable<TipoInscricaoRascunhoQuery> ObterTodosTipoInscricao(string aliasUsuario) => _tipoInscricaoRepository.ObterTodosRascunhosTipoInscricaoUsuario(aliasUsuario);

        /// <summary>
        ///  Insere novo tipo de inscrição
        /// </summary>
        /// <remarks>Insere novo tipo de inscrição</remarks>        
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("v1/tipo/inscricao")]
        public async Task<IActionResult> Post([FromBody] InserirTipoInscricaoCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        /// <summary>
        ///  Insere ou atualiza um rascunho do tipo de inscrição
        /// </summary>
        /// <remarks>Insere ou atualiza um rascunho do tipo de inscrição</remarks>        
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("v1/rasculho/tipo/inscricao")]
        public async Task<IActionResult> PostRasculho([FromBody] RascunhoTipoInscricaoCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        /// <summary>
        ///  Altera um tipo de inscrição
        /// </summary>
        /// <remarks>Altera um tipo de inscrição</remarks>
        /// <param name="id">ID Tipo Inscrição</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [Route("v1/tipo/inscricao/{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AlterarTipoInscricaoCommand command)
        {
            command.Id = id;
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

    }
}
