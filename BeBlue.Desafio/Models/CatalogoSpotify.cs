using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeBlue.Desafio.Models
{
    public class CatalogoSpotify
    {
        public string Album{ get; set; }
        public string Artista { get; set; }
        public string Genero{ get; set; }
        public string ImageUrl { get; set; }

    }
}
