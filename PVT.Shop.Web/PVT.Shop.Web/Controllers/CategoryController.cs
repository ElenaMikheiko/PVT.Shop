namespace PVT.Shop.Web.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            this._service = service;
        }

        #region Actions

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return this.RedirectToAction("GetCategory", new { id = 1 });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetCategory(int id = 1)
        {
            return this.View(this._service.GetCategory(id));
        }

        public ActionResult CategoryProducts(string q, int id = 1, int page = 1, int pageSize = 30)
        {
            if (!string.IsNullOrEmpty(q))
            {
                ViewBag.SearchQuery = q;
            }

            return this.View(this._service.GetCategoryProducts(q, id, page, pageSize));
        }

        [HttpPost]
        public ActionResult CategoryProducts(CategoryProductsViewModel categoryProducts)
        {
            return this.View(this._service.SearchCategoryProducts(categoryProducts.SearchString));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UpdateCategoryState(int id, bool isDeleted)
        {
            this._service.UpdateCategoryState(id, isDeleted);

            return this.RedirectToAction("GetCategory", new { id = this._service.GetParentId(id) });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(int id = 0, int parentId = 1)
        {
            return this.View(this._service.GetCategoryForEdit(id, parentId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory([ModelBinder(typeof(CategoryModelBinder))] Category category)
        {
            if (!ModelState.IsValid)
            {
                return this.View(this._service.GetCategoryForEdit(category.Id));
            }

            this._service.SaveCategory(category);
            return this.RedirectToAction("GetCategory", new { id = category.Parent.Id });
        }

        public ActionResult Catalog()
        {
            return this.PartialView(this._service.GetCatalog());
        }

        #endregion
    }
}