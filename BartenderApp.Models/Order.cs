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

        [Display(Name = "Cocktail Name")]
        public string CocktailName { get; set; }

        [Display(Name = "Ready for Pickup")]
        public bool IsReady { get; set; }

    }
}
