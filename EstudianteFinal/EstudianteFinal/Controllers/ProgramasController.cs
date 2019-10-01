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

    public class ProgramasController : ControllerBase
    {
        private IProgramasService programaService;


        public ProgramasController(IProgramasService programaService)
        {
            this.programaService = programaService;
        }

        [HttpPost]
        public ActionResult<Programa> PostStudent([FromBody] Programa student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createStudent = programaService.CreatePrograma(student);
            return Created($"/api/student/{createStudent.id}", createStudent);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Programa>> GetPrograma(string orderBy = "id")
        {
            try
            {
                return Ok(programaService.GetProgramas(orderBy));
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Programa> GetPrograma(int id)
        {
            try
            {
                return Ok(programaService.GetPrograma(id));
            }

            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Programa> PutStudent(int id, [FromBody]Programa student)
        {
            try
            {
                return Ok(programaService.UptatePrograma(id, student));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeletePrograma(int id)
        {
            try
            {
                var result = programaService.DeletePrograma(id);
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
