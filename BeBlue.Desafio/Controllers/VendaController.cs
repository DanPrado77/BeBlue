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
    public class VendaController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;

        public VendaController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<Venda> Get()
        {
            return _beBlue.Vendas.ToList();
        }

        [HttpGet("{id}")]
        public Venda Get(int id)
        {
            return _beBlue.Vendas.Find(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Venda venda)
        {
            _beBlue.Vendas.Add(venda);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Venda adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]Venda venda)
        {
            _beBlue.Entry(venda).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Venda alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.Vendas.Remove(_beBlue.Vendas.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Venda removido com sucesso!");
        }

        [HttpGet]
        public List<Venda> GetVendaPaginada(DateTime dtInicio, DateTime dtFim, int pagina, int qtdPagina)
        {            
            List<Venda> _vendas = _beBlue.Vendas.ToList().Where(d => d.DtVenda >= dtInicio && d.DtVenda <= dtFim).OrderBy(x=> x.DtVenda).ToList();
            return _vendas.Skip(pagina * qtdPagina).Take(qtdPagina).ToList();
        }
    }
}
