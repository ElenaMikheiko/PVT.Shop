namespace PVT.Shop.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Authentication;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class BasketController : Controller
    {
        private readonly IProductService _productRepository;

        public BasketController(IProductService repository)
        {
            this._productRepository = repository;
        }

        public ActionResult AddToBasket(int id)
        {
            var product = this._productRepository.GetProducts().FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                this.GetBasket().AddItem(product, 1);
            }

            return this.RedirectToAction("BasketSummary");
        }

        public RedirectToRouteResult RemoveFromBasket(int id, string returnUrl)
        {
            var product = this._productRepository.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                this.GetBasket().RemoveItem(product);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return this.View(new BasketViewModel
            {
                Basket = this.GetBasket(),
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult BasketSummary(Basket basket)
        {
            return this.PartialView(this.GetBasket());
        }

        public Basket GetBasket()
        {
            string key = null;

            if (Request.IsAuthenticated)
            {
                if (HttpContext.Session != null)
                {
                    key = (((UserPrincipal)User).Id + HttpContext.Session.SessionID).GetHashCode().ToString();
                }
            }
            else
            {
                if (HttpContext.Session != null)
                {
                    key = (Request.AnonymousID + HttpContext.Session.SessionID).GetHashCode().ToString();
                }
            }

            var basket = (Basket)Session[key];

            if (basket != null)
            {
                return basket;               
            }

            basket = new Basket(key);

            this.Session[key] = basket;

            return basket;
        }
    }
}