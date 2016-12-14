namespace PVT.Shop.Infrastructure.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class OrderViewModel
    {
        [Required]
        public User OrderUser { get; set; }

        [Required]
        public Basket OrderBasket { get; set; }
    }
}