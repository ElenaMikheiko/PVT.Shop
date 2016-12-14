namespace PVT.Shop.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            /// Basket routes
            routes.MapRoute(
                    name: "Basket",
                    url: "Basket",
                    defaults: new { controller = "Basket", action = "BasketSummary" });

            routes.MapRoute(
                name: "BasketIndex",
                url: "Basket/Index/{id}",
                defaults: new { controller = "Basket", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "BasketSummary",
                url: "Basket/BasketSummary/{id}",
                defaults: new { controller = "Basket", action = "BasketSummary", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "AddToBasket",
                url: "Basket/AddToBasket/{id}",
                defaults: new { controller = "Basket", action = "AddToBasket", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "RemoveFromBasket",
                url: "Basket/RemoveFromBasket/{id}",
                defaults: new { controller = "Basket", action = "RemoveFromBasket", id = UrlParameter.Optional });

            //// Storage routes

            routes.MapRoute(
                    name: "Storage",
                    url: "Storage",
                    defaults: new { controller = "Storage", action = "Index" });

            routes.MapRoute(
                name: "StorageIndex",
                url: "Storage/Index/{id}",
                defaults: new { controller = "Storage", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "StorageEdit",
                url: "Storage/Edit/{id}",
                defaults: new { controller = "Storage", action = "Edit", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "StorageDetail",
                url: "Storage/Detail/{id}",
                defaults: new { controller = "Storage", action = "Detail", id = UrlParameter.Optional });

            //// Category routes
            
            routes.MapRoute(
                    name: "Category",
                    url: "Category",
                    defaults: new { controller = "Category", action = "Index" });

            routes.MapRoute(
                name: "CategoryIndex",
                url: "Category/Index/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "CategoryEdit",
                url: "Category/Edit/{id}",
                defaults: new { controller = "Category", action = "Edit", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "CategoryDelete",
                url: "Category/Delete/{id}",
                defaults: new { controller = "Category", action = "Delete", id = UrlParameter.Optional });

            //// Product Routes

            routes.MapRoute(
                   name: "Product",
                   url: "products",
                   defaults: new { controller = "Product", action = "Index" });

            routes.MapRoute(
                name: "ProductEdit",
                url: "products/editProduct",
                defaults: new { controller = "Product", action = "EditProduct" });

            routes.MapRoute(
                name: "ProductAdd",
                url: "products/addProduct",
                defaults: new { controller = "Product", action = "AddProduct", id = UrlParameter.Optional });

            //// Account Routes

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Account", action = "Login" }); 

           routes.MapRoute(
                name: "Registration",
                url: "registration",
                defaults: new { controller = "User", action = "RegistrationUser" });

            routes.MapRoute(
                name: "Tools",
                url: "onlinerparser",
                defaults: new { controller = "Account", action = "Tools" });

            //// Catalog Route

            routes.MapRoute(
                name: "Catalog",
                url: "catalog",
                defaults: new { controller = "Category", action = "CategoryProducts" });

            //// About Route

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" });

            ////Index Route

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Category", action = "CategoryProducts", id = UrlParameter.Optional });
        }
    }
}
