using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeBlue.Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace BeBlue.Desafio.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;

        public GeneroController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<Genero> Get()
        {
            return _beBlue.Generos.ToList();
        }

        [HttpGet("{id}")]
        public Genero Get(int id)
        {
            return _beBlue.Generos.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Genero genero)
        {
            _beBlue.Generos.Add(genero);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Genero adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]Genero genero)
        {
            _beBlue.Entry(genero).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Genero alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.Generos.Remove(_beBlue.Generos.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Genero removido com sucesso!");
        }
    }
}
