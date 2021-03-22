using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Models
{
    public class FBwynik
    {
        [Display(Name = "Podaj liczbę: ")]
        [Range(1, 1000, ErrorMessage ="Liczba musi być z zakresu od 1 do 1000")]
        public int Number { get; set; }
        public DateTime thisDay = DateTime.Today;
    }
}
