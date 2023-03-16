using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public AutoresController(AppDbContext context) 
        {
            this.context = context;
        }



        [HttpGet]
        public async Task <ActionResult<List<Autor>>> Get()
        {
            {
               return await context.Autores.ToListAsync();

            };


        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor); 
            await context.SaveChangesAsync();
            return Ok();
        }
    
    }

}

