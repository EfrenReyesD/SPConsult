using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

 public class MiServicio
    {
        private readonly MyDbContext _context;

        public MiServicio(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultadoProcedimiento>> EjecutarProcedimientoAsync(int parametro1)
        {
            var resultado = await _context.Set<ResultadoProcedimiento>()
                .FromSqlRaw("EXEC sp_CalcularPuntosPago @param1", 
                    new SqlParameter("@param1", parametro1))
                .ToListAsync();

            return resultado;
        }
    }