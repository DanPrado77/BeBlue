using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeBlue.Desafio.Models
{
    public class ItensVenda
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdVenda{ get; set; }
        [Required]
        public int IdAlbum { get; set; }
        [Required]
        public decimal TotalItem { get; set; }
        [Required]
        public decimal CashBack{ get; set; }
    }
}
