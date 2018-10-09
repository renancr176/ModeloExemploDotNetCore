using Microsoft.AspNetCore.Mvc;
using Extensao.Infra.Data.Transactions;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidator;
using System.Linq;

namespace Extensao.Services.Api.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch
                {
                    // Logar o erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}