using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BartenderApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CocktailId { get; set; }
        [ForeignKey("CocktailId")]
        public Cocktail Cocktail { get; set; }

    }
}
