   
using Microsoft.AspNetCore.Mvc;
   
   
    [ApiController]
    [Route("api/[controller]")]
    public class MiControlador : ControllerBase
    {
        private readonly MiServicio _servicio;

        public MiControlador(MiServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("{parametro1}")]
        public async Task<ActionResult<List<ResultadoProcedimiento>>> ObtenerResultados(int parametro1)
        {
            var resultados = await _servicio.EjecutarProcedimientoAsync(parametro1);
            return Ok(resultados);
        }
    }