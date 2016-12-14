namespace PVT.Shop.Web.Common
{
    using System.Web.Mvc;
    using Infrastructure.Common;

    public class BasketModelBinder : IModelBinder
    {
        private readonly string _sessionKey;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            if (controllerContext.HttpContext.Session == null)
            {
                return new Basket(this._sessionKey);
            }

            var basket = (Basket)controllerContext.HttpContext.Session[this._sessionKey];

            if (basket != null)
            {
                return basket;
            }

            basket = new Basket(this._sessionKey);
            controllerContext.HttpContext.Session[this._sessionKey] = basket;

            return basket;
        }
    }
}