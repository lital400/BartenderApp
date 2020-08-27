using System.ComponentModel.DataAnnotations;


namespace BartenderApp.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order Id")]
        public int Id { get; set; }

        [Display(Name = "Cocktail Name")]
        public string CocktailName { get; set; }

        [Display(Name = "Ready for Pickup")]
        public bool IsReady { get; set; }

    }
}
