using Extensao.Infra.Data.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Extensao.Services.Api.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUow uow): base(uow)
        {
        }

        /// <summary>
        /// Api Aluno Barão de Mauá
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { Version = "Extensão Version 1.0.0" };
        }
    }
}
