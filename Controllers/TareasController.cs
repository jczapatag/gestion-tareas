using Microsoft.AspNetCore.Mvc;
using Gestion_Tareas.Models;

namespace Gestion_Tareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        // Lista en memoria (simula una "tabla" de base de datos)
        private static readonly List<TaskModel> _tareas = new();

        // GET /api/tareas
        [HttpGet]
        public ActionResult<List<TaskModel>> GetTareas()
        {
            return Ok(_tareas);
        }
    }
}
