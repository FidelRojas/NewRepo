using EstudianteFinal.Models;
using EstudianteFinal.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudianteFinal.Controllers
{
    [Route("api/[controller]")]

    public class EstudiantesController : ControllerBase
    {
        private IEstudianteService estudianteService;


        public EstudiantesController(IEstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
        }

        [HttpPost]
        public ActionResult<Estudiante> PostStudent([FromBody] Estudiante student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createStudent = estudianteService.CreateEstudiante(student);
            return Created($"/api/student/{createStudent.id}", createStudent);
           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiante(string orderBy = "id")
        {
            try
            {
                return Ok(estudianteService.GetEstudiantes(orderBy));
            }
            
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetEstudiante(int id)
        {
            try
            {
                return Ok(estudianteService.GetEstudiante(id));
            }
           
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Estudiante> PutStudent(int id, [FromBody]Estudiante student)
        {
            try
            {
                return Ok(estudianteService.UptateEstudiante(id, student));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteEstudiante(int id)
        {
            try
            {
                var result = estudianteService.DeleteEstudiante(id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete author");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
