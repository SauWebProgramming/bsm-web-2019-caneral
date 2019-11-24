using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastgeleFilm.Models
{
    public class Movie
    {
        public int FilmId { get; set; }
        public string FilmAd { get; set; }
        public string FilmTur { get; set; }
        public float FilmPuan { get; set; }
        public bool FilmKategori { get; set; }
        public string Resim { get; set; }
        public string Video { get; set; }
        public string Aciklama { get; set; }
    }
}
