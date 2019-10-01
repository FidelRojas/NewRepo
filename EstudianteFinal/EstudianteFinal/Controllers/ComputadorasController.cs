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
        private IProgramasService programasService;
        private IComputadorasService computadorasService;
        private IEstudianteService estudianteService;

        public ComputadorasController(IComputadorasService computadorasService, IEstudianteService estudianteService, IProgramasService programasService)
        {
            this.computadorasService = computadorasService;
            this.estudianteService = estudianteService;
            this.programasService = programasService;
        }

        [HttpPost]
        public ActionResult<Computadora> PostStudent([FromBody] Computadora student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createStudent = computadorasService.CreateComputadora(student);
            return Created($"/api/student/{createStudent.id}", createStudent);
           
        }

        [HttpGet]
        public ActionResult<IEnumerable<Computadora>> GetComputadora(string orderBy = "id")
        {
            try
            {
                return Ok(computadorasService.GetComputadoras(orderBy));
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
                return Ok(computadorasService.GetComputadora(id));
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
                return Ok(computadorasService.UptateComputadora(id, student));
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
                var result = computadorasService.DeleteComputadora(id);
                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, "cannot delete author");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{Ci}/{ComputadoraId}")]
        public ActionResult<List<Programa>> ObtenerProgramasDeEstudiante(int idEstudiante, int ComputadoraId)
        {
            Estudiante estudiante = estudianteService.obtenerEstudiante(idEstudiante);

            var programas = programasService.GetProgramas("id").ToList();
            List<Programa> programass = computadorasService.ObtenerProgramasDeEstudiante(estudiante, ComputadoraId, programas);
            return programass;
        }
    }
}