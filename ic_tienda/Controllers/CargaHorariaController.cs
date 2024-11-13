using ic_tienda_data.sources.BaseDeDatos;
using ic_tienda_data.sources.BaseDeDatos.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda.Controllers
{
    [ApiController]
    [Route("/api/v1/cargahoraria")]
    public class CargaHorariaController : ControllerBase
    {
        private readonly IcTiendaDbContext _context; // Contexto de la base de datos
        private readonly ILogger<CargaHorariaController> _logger; // Logger para registrar errores

        // Constructor que inyecta el contexto de la base de datos y el logger
        public CargaHorariaController(IcTiendaDbContext context, ILogger<CargaHorariaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Método GET para listar todas las cargas horarias
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CargaHorariaTable>>> ListarAsync()
        {
            try
            {
                // Consulta para obtener todas las cargas horarias de la tabla
                List<CargaHorariaTable> cargasHorarias = await _context.cargas_horarias.ToListAsync();
                return Ok(cargasHorarias);
            }
            catch (Exception ex)
            {
                // En caso de error, se registra en el logger y se devuelve una respuesta de error
                _logger.LogError($"[CargaHorariaController][ListarAsync] {ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new { error = true, message = "Error al obtener las cargas horarias." });
            }
        }
    }
}
