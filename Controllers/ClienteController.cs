using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_demarco.Interfaces;
using teste_demarco.Models.Integracao;

namespace teste_demarco.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _service.GetAll();

                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] ClienteDto entity)
        {
            try
            {
                var data = await _service.Save(entity);

                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
