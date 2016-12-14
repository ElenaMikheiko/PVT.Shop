namespace PVT.Shop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Authentication;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;
    using PagedList;

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            this._orderService = orderService;
            this._userService = userService;
        }

        [Authorize]
        public PartialViewResult Index(int page = 1, int pageSize = 5)
        {
            var userRole = ((Authentication.UserPrincipal)User).CurrentRole;
            var userId = ((Authentication.UserPrincipal)User).Id;
            ViewBag.Role = userRole.ToString();
            var query = this._orderService.GetOrders();
            switch (userRole)
            {
                case Infrastructure.Common.Role.User:
                    query = this._orderService.GetOrders(userId);
                    break;
                case Infrastructure.Common.Role.Seller:
                    query = this._orderService.GetOrdersBySel(userId);
                    break;
                case Infrastructure.Common.Role.Admin:
                    query = this._orderService.GetOrders();
                    break;
                default:
                    break;
            }

            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 5;

            return this.PartialView(query.ToPagedList(page, pageSize));
        }

        public ActionResult CreateOrder(string key)
        {
            User user = null;

            if (Request.IsAuthenticated)
            {
                user = this._userService.GetUser(((UserPrincipal)User).Id);
            }

            var vm = new OrderViewModel
            {
                OrderBasket = this.GetBasket()
            };

            if (user != null)
            {
                vm.OrderUser = user;
            }

            return this.View(vm);
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderViewModel ordervm)
        {
            var order = new Order
            {
                UserName = ordervm.OrderUser.FirstName + ordervm.OrderUser.LastName,
                UserId = ordervm.OrderUser.Id,
                DateAdded = DateTime.Now,
                Delivered = false,
                PhoneNumber = ordervm.OrderUser.Phone,
                Delivery = ordervm.OrderUser.Address,
                IsDeleted = false,
                DeliveryType = DeliveryType.Сourier,                                      
            };

            ordervm.OrderBasket = this.GetBasket();

            IList<BasketProductID> bpi = new List<BasketProductID>();

            foreach (var p in ordervm.OrderBasket.BasketItems)
            {

                var basketproductid = new BasketProductID
                {
                    ProductId = p.Product.Id,
                    ProductName = p.Product.Name,
                    ProductCount = p.Product.Count
                };

                bpi.Add(basketproductid);
            }

            order.BasketProductID = bpi.ToList();

            this._orderService.AddOrder(order);
            this._orderService.SaveChanges();

            this.GetBasket().Clear();

            return this.RedirectToAction("CategoryProducts", "Category");
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

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteOrder(int id)
        {
            this._orderService.DeleteOrder(id);
            return this.RedirectToAction("Index");
        }
    }
}