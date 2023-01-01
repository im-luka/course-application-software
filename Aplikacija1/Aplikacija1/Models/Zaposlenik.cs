using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aplikacija1.Models
{
    public class Zaposlenik
    {
        [Key]
        public int ZaposlenikID { get; set; }

        [Required(ErrorMessage = "Ime je obavezno!")]
        [StringLength(20, ErrorMessage = "Ime ne smije biti veće od 20 znakova!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(20, ErrorMessage = "Prezime ne smije biti veće od 20 znakova!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        [StringLength(20, ErrorMessage = "Korisničko ime ne smije biti veće od 20 znakova!")]
        [Display(Name = "Korisničko ime")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna!")]
        [StringLength(maximumLength: 30, MinimumLength = 8, ErrorMessage = "Lozinka mora biti između 8 i 30 znakova!")]
        [Display(Name = "Lozinka"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}