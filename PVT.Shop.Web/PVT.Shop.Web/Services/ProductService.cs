namespace PVT.Shop.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using DAL.Repositories;
    using Infrastructure.Common;
    using Infrastructure.Common.ViewModels;
    using Infrastructure.Services;

    public class ProductService : IProductService
    {
        private readonly Repository<Product> _repository;

        public ProductService(Repository<Product> repository)
        {
            this._repository = repository;
        }

        public void AddProduct(Product product)
        {
            this._repository.Create(product);
        }

        public void DeleteProduct(int id)
        {
            this._repository.Delete(id);
        }

        public void UpdateProduct(Product product)
        {
            this._repository.Update(product);
        }

        public Product GetProduct(int id)
        {
            return this._repository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._repository.GetAll();
        }
     
        public IEnumerable<Product> GetProducts(string sortOrder, int userId)
        {
            var query = this._repository.GetAll().Where(p => p.CurrentUser.Id == userId);

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                query = this._repository.GetAll();
            }

            switch (sortOrder)
            {
                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case "id":
                    query = query.OrderBy(x => x.Id);
                    break;
                case "id_desc":
                    query = query.OrderByDescending(x => x.Id);
                    break;
                case "count":
                    query = query.OrderBy(x => x.Count);
                    break;
                case "count_desc":
                    query = query.OrderByDescending(x => x.Count);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    break;
            }

            return query;
        }

        public void SaveChanges()
        {
            this._repository.Save();
        }
    }
}