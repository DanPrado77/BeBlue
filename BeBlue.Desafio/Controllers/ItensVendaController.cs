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
    public class ItensVendaController : ControllerBase
    {
        private readonly BeBlueDesafio _beBlue;
        private Album _album = null;
        private CashBack _cashBack = null;

        public ItensVendaController(BeBlueDesafio beBlue)
        {
            _beBlue = beBlue;
        }

        [HttpGet]
        public List<ItensVenda> Get()
        {
            return _beBlue.ItensVenda.ToList();
        }

        [HttpGet("{id}")]
        public ItensVenda Get(int id)
        {
            return _beBlue.ItensVenda.Find(id);
        }

        [HttpGet("{idAlbum}")]
        public decimal GetTotalAlbum(int idAlbum)
        {
            try
            {
                return _beBlue.Albuns.Find(idAlbum).Preco;
                
            }
            catch { return 0.00M; }

        }

        [HttpGet("{idGenero}/{diaSemana}/{idAlbum}")]
        public decimal GetCashBack(int idGenero, int diaSemana, int idAlbum)
        {
            try
            {
                decimal _retornoCash = 0.00M;
                _album = _beBlue.Albuns.Find(idAlbum);
                _cashBack = _beBlue.CashBack.Where(c => c.IdGenero.Equals(idGenero) && c.DiaSemana.Equals(diaSemana)).First();

                _retornoCash = ((_album.Preco * _cashBack.Porcentagem) / 100);

                return _retornoCash;
            }
            catch { return 0.00M; }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ItensVenda itemVenda)
        {
            _beBlue.ItensVenda.Add(itemVenda);
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Item adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]ItensVenda itemVenda)
        {
            _beBlue.Entry(itemVenda).State = EntityState.Modified;
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Item alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _beBlue.ItensVenda.Remove(_beBlue.ItensVenda.Find(id));
            await _beBlue.SaveChangesAsync();
            return new ObjectResult("Item removido com sucesso!");
        }
    }
}
