using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudianteFinal.Models;
using EstudianteFinal.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputadoraFinal.Controllers
{
    [Route("api/[controller]")]

    public class ComputadorasController : ControllerBase
    {
        private IComputadorasService estudianteService;


        public ComputadorasController(IComputadorasService estudianteService)
        {
            this.estudianteService = estudianteService;
        }

        [HttpPost]
        public ActionResult<Computadora> PostStudent([FromBody] Computadora student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createStudent = estudianteService.CreateComputadora(student);
            return Created($"/api/student/{createStudent.id}", createStudent);
           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Computadora>> GetComputadora(string orderBy = "id")
        {
            try
            {
                return Ok(estudianteService.GetComputadoras(orderBy));
            }
            
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Computadora> GetComputadora(int id)
        {
            try
            {
                return Ok(estudianteService.GetComputadora(id));
            }
           
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Computadora> PutStudent(int id, [FromBody]Computadora student)
        {
            try
            {
                return Ok(estudianteService.UptateComputadora(id, student));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteComputadora(int id)
        {
            try
            {
                var result = estudianteService.DeleteComputadora(id);
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