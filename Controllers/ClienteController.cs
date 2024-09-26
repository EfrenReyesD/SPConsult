using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClientesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes); // Devuelve la lista de clientes
        }

        // GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound(); // Devuelve 404 si no se encuentra el cliente
            }

            return Ok(cliente); // Devuelve el cliente encontrado
        }

// GET: api/clientes/nombre/{nombre}
[HttpGet("nombre/{nombre}")]
public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesPorNombre(string nombre)
{
    var clientes = await _context.Clientes
        .Where(c => c.Nombre != null && c.Nombre.ToLower() == nombre.ToLower())
        .ToListAsync();

    if (clientes == null || !clientes.Any())
    {
        return NotFound(); // Devuelve 404 si no se encuentran clientes con ese nombre
    }

    return Ok(clientes); // Devuelve la lista de clientes encontrados
}




    }
}
