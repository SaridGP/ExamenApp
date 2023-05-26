using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceAPI.Data;
using WebServiceAPI.Models;

namespace WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamenesController : Controller
    {
        private readonly ExamenesDbContext _dbcontext;

        public ExamenesController(ExamenesDbContext dbContext) 
        {
            this._dbcontext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetExamenes()
        {
            return Ok(await _dbcontext.tblExamen.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            var examen = await _dbcontext.tblExamen.FindAsync(id);
            
            if (examen != null)
            {
                return Ok(examen);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddExamen(AddExamenRequest addExamen)
        {
            var examen = new tblExamen()
            { 
                Nombre = addExamen.Nombre, 
                Descripcion = addExamen.Descripcion
            };

            await _dbcontext.tblExamen.AddAsync(examen);
            await _dbcontext.SaveChangesAsync();

            return Ok(examen);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateExamen([FromRoute] int id, UpdateExamenRequest updateExamen)
        {
            var examen = await _dbcontext.tblExamen.FindAsync(id);

            if (examen != null)
            {
                examen.Nombre = updateExamen.Nombre;
                examen.Descripcion = updateExamen.Descripcion;

                await _dbcontext.SaveChangesAsync();

                return Ok(examen);
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteExamen([FromRoute] int id)
        {
            var examen = await _dbcontext.tblExamen.FindAsync(id);

            if (examen != null)
            {
                _dbcontext.Remove(examen);
                await _dbcontext.SaveChangesAsync();
                return Ok(examen);
            }

            return NotFound();
        }
    }
}
