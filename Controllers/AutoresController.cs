﻿using Microsoft.AspNetCore.Mvc;
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
               return await context.Autores.Include(x => x.Libros).ToListAsync();

            };


        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor); 
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("/{id:int}")]
        public async Task <ActionResult> Put(Autor autor, int id)
        {
            if( autor.Id != id)
            {
                return BadRequest("El id No coincide con el de la Url");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            
            var existe = await context.Autores.AnyAsync(author => author.Id == id);
            if(!existe)
            {
                return NotFound("No existe ese autor");
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    
    }

}

