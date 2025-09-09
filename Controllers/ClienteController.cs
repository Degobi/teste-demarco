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

        [HttpGet, Route(""), AllowAnonymous]
        public async Task<IResult> Get()
        {
            try
            {
                var data = await _service.GetAll();

                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost, Route(""), AllowAnonymous]
        public async Task<IResult> Post([FromBody] ClienteDto entity)
        {
            try
            {
                var data = await _service.Save(entity);

                return Results.Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
