using System;
using System.ComponentModel.DataAnnotations;
using LeanWorkProject.Helpers;

namespace LeanWorkProject.Models
{
    public class Card
    {
        [StringLength(60, MinimumLength = 13)]
        [Required]
        public string Number { get; set; }
        public string OwnerName { get; set; }
        [StringLength(15, MinimumLength = 4)]
        [Required]
        public string CardFlag { get; set; }
        public string ExpiringDate { get; set; }
        public bool? Valid { get; private set; }
        
        
        //Verificar se o cartão é válido
        public bool Validate()
        {
            this.Number = this.Number.Replace(" ", "");
            if (String.IsNullOrEmpty(this.Number) || this.Number.Length < 13) // 13 is the minimum legth for valid number card, on accepted flags.
                return false;

            if (String.IsNullOrEmpty(this.Number) || this.Number.Length < 13) // 13 is the minimum legth for valid number card, on accepted flags.
                return false;

            bool result = CardValidator.Validate(this);
            this.Valid = result;
            return result;
        }
    }
}