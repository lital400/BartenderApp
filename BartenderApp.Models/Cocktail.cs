﻿using System.ComponentModel.DataAnnotations;


namespace BartenderApp.Models
{
    public class Cocktail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cocktail Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
