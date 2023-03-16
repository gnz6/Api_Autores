using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("/api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext context;

        public LibrosController(AppDbContext context) 
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> GetOne(int id)
        {
            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Libro>>Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync( autor => autor.Id == libro.AutorId);

            if(!existeAutor)
            {
                return BadRequest("No existe ese autor");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();   
        }

    }
}
