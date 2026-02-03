using Microsoft.AspNetCore.Mvc;
using Gestion_Tareas.Models;
using Gestion_Tareas.Dtos;
using System.Linq;



namespace Gestion_Tareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private static readonly List<TaskModel> _tareas = new();
        private static int _nextId = 1;

    [HttpGet]
    public ActionResult<List<TaskModel>> GetTareas()
    {
        return Ok(_tareas);
    }

    [HttpPost]
    public ActionResult<TaskModel> CreateTarea(CreateTaskDto createTaskDto)
    {
        var nuevaTarea = new TaskModel
        {
            Id = _nextId++,
            Title = createTaskDto.Title,
            Description = createTaskDto.Description
        };
        _tareas.Add(nuevaTarea);
        return CreatedAtAction(nameof(GetTareas), new { id = nuevaTarea.Id }, nuevaTarea);
    }
    [HttpPut("{id}")]
public ActionResult<TaskModel> UpdateTarea(int id, [FromBody] UpdateTaskDto dto)
{
    // 1) Buscar la tarea existente
    var tareaExistente = _tareas.FirstOrDefault(t => t.Id == id);

    // 2) Si no existe, responder 404
    if (tareaExistente == null)
    {
        return NotFound($"No se encontró una tarea con Id = {id}");
    }

    // 3) Actualizar los campos permitidos
    tareaExistente.Title = dto.Title;
    tareaExistente.Description = dto.Description;

    // 4) Responder 200 con la tarea actualizada
    return Ok(tareaExistente);
}

}
}
