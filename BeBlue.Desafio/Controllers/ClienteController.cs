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
    public class ClienteController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;

        public ClienteController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return _beBlue.Clientes.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _beBlue.Clientes.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Cliente cliente)
        {
            _beBlue.Clientes.Add(cliente);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Cliente adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]Cliente cliente)
        {
            _beBlue.Entry(cliente).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Cliente alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.Clientes.Remove(_beBlue.Clientes.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Cliente removido com sucesso!");
        }
    }
}
