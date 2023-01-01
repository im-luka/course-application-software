using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikacija1.Models
{
    public class Predbiljezba
    {
        [Key]
        public int PredbiljezbaID { get; set; }

        //[Required(ErrorMessage = "Datum je obavezan!")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage = "Datum je obavezan!")]
        [StringLength(20)]
        public string Datum { get; set; }

        [Required(ErrorMessage = "Ime je obavezno!")]
        [StringLength(20, ErrorMessage = "Ime može imati najviše 20 znakova!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(20, ErrorMessage = "Prezime može imati najviše 20 znakova!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Adresa je obavezna!")]
        [StringLength(30, ErrorMessage = "Adresa može imati najviše 30 znakova!")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "E-mail je obavezan!")]
        [StringLength(50, ErrorMessage = "E-mail može imati najviše 50 znakova!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Broj telefona je obavezan!")]
        [StringLength(30, ErrorMessage = "Broj telefona može imati najviše 30 znakova!")]
        [Display(Name = "Broj telefona")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Neispravan broj telefona!")]
        public string Telefon { get; set; }

        [Required]
        [ForeignKey("Seminar")]
        public int SeminarID { get; set; }
        public virtual Seminar Seminar { get; set; }

        [Display(Name = "Prihvaćen")]
        public bool Status { get; set; }
    }
}