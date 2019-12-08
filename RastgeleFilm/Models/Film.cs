using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RastgeleFilm.Models
{
    public class Film
    {
        [Key]
        [DisplayName("Film Id")]
        public int FilmId { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        [Column(TypeName ="varchar(200)")]
        [DisplayName("Film Ad")]
        public string FilmAd { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Film Tür")]
        public string FilmTur { get; set; }
        [Required]
        [Column(TypeName = "float")]
        [DisplayName("Film Puan")]
        public float FilmPuan { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        [DisplayName("Film Kategori")]
        public bool FilmKategori { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        [DisplayName("Resim Yolu")]
        public string ResimYolu { get; set; }
        [Required]
        [Column(TypeName = "varchar(400)")]
        [DisplayName("Video Yolu")]
        public string VideoYolu { get; set; }
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        [DisplayName("Film Açıklama")]
        public string FilmAciklama { get; set; }

    }
}
