using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeBlue.Desafio.Models
{
    public class BeBlueDesafio : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<CashBack> CashBack { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItensVenda> ItensVenda { get; set; }

        public BeBlueDesafio()
        {

        }
        public BeBlueDesafio(DbContextOptions options) : base(options) { }
    }
}
