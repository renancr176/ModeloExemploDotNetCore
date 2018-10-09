using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Extensao.Domain.Proposta.Queries;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.Transactions;

namespace Extensao.Services.Api.Controllers
{
    public class PropostaController : BaseController
    {

        private readonly ITipoInscricaoRepository _tipoInscricaoRepository;

        public PropostaController(IUow uow, 
            ITipoInscricaoRepository tipoInscricaoRepository) : base(uow)
        {
            _tipoInscricaoRepository = tipoInscricaoRepository;
        }

       
    }
}