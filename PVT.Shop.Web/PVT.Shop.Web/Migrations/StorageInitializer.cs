namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL;
    using Infrastructure.Common;

    public static class StorageInitializer
    {
        public static void Initialize(ShopContext context)
        {
            if (context.Storages.Any())
            {
                return;
            }

            context.Storages.AddOrUpdate(
                new Storage
                {
                    Name = "Global Storage",
                    Address = new Address
                    {
                        City = "Minsk",
                        Postcode = "123456",
                        ApartmentNumber = "123",
                        HomeNumber = "123",
                        Street = "Minskay"
                    },
                    PhoneNumber = "12345600"
                },
                new Storage
                {
                    Name = "Other Page",
                    Address = new Address
                    {
                        City = "Pinsk",
                        Postcode = "654321",
                        ApartmentNumber = "654",
                        HomeNumber = "654",
                        Street = "Pinskay"
                    },
                    PhoneNumber = "65432100"
                });

            foreach (var storage in context.Storages.Local)
            {
                storage.Address.Country = context.Countries.Local.FirstOrDefault(c => c.Name == "Belarus");
            }
        }
    }
}