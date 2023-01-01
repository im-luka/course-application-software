using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aplikacija1.Models
{
    public class Seminar
    {
        [Key]
        public int SeminarID { get; set; }

        [Required(ErrorMessage = "Naziv seminara je obavezan!")]
        [StringLength(150, ErrorMessage = "Naziv seminara može imati najviše 150 znakova!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Opis seminara je obavezan!")]
        [StringLength(500, ErrorMessage = "Naziv seminara može imati najviše 500 znakova!")]
        public string Opis { get; set; }

        //[Required(ErrorMessage = "Datum je obavezan!")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Datum je obavezan!")]
        [StringLength(20)]
        public string Datum { get; set; }

        public bool Popunjen { get; set; }
    }
}