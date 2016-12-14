namespace PVT.Shop.Web.Migrations
{
    using System.Data.Entity.Migrations;
    using DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopContext context)
        {
            CountryInitializer.Initialize(context);

            StorageInitializer.Initialize(context);

            UsersInitializer.Initialize(context);

            CategoriesInitializer.Initialize(context);

            OrderInitializer.Initialize(context);

            context.SaveChanges();
        }
    }
}