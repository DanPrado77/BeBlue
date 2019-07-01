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
    public class CashBackController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;

        public CashBackController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<CashBack> Get()
        {
            return _beBlue.CashBack.ToList();
        }

        [HttpGet("{id}")]
        public CashBack Get(int id)
        {
            return _beBlue.CashBack.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CashBack obj)
        {
            _beBlue.CashBack.Add(obj);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("CashBack adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]CashBack obj)
        {
            _beBlue.Entry(obj).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("CashBack alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.CashBack.Remove(_beBlue.CashBack.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("CashBack removido com sucesso!");
        }
    }
}
