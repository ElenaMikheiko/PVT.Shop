namespace PVT.Shop.Web.Migrations
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public static class CountryInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            context.Countries.AddRange(new List<Country>()
            {
                new Country() { Name = "Belarus" },
                new Country() { Name = "Russia" },
                new Country() { Name = "Ukraine" },
                new Country() { Name = "Poland" },
                new Country() { Name = "Latvia" },
                new Country() { Name = "Lithuania" },
                new Country() { Name = "England" },
                new Country() { Name = "USA" },
                new Country() { Name = "NewZeland" },
                new Country() { Name = "Bulgary" },
                new Country() { Name = "Israel" },
                new Country() { Name = "Germany" },
                new Country() { Name = "Albania" },
                new Country() { Name = "SAR" },
                new Country() { Name = "Austria" },
                new Country() { Name = "Bahrain" },
                new Country() { Name = "Belgium" },
                new Country() { Name = "Canada" },
                new Country() { Name = "Cuba" },
                new Country() { Name = "Czechia" },
                new Country() { Name = "Estonia" },
                new Country() { Name = "Finland" },
                new Country() { Name = "France" },
                new Country() { Name = "Greece" },
                new Country() { Name = "Honduras" },
                new Country() { Name = "Iceland" },
                new Country() { Name = "Kuwait" },
                new Country() { Name = "Luxembourg" },
                new Country() { Name = "Montenegro" },
                new Country() { Name = "Portugal" },
                new Country() { Name = "Somalia" },
                new Country() { Name = "Sweden" },
                new Country() { Name = "Switzerland" },
                new Country() { Name = "Taiwan" },
                new Country() { Name = "Tuvalu" },
                new Country() { Name = "Venezuela" },
                new Country() { Name = "Zimbabwe" },
                new Country() { Name = "Uganda" },
                new Country() { Name = "Thailand" },
                new Country() { Name = "Singapore" }
            });
        }
    }
}