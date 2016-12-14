namespace PVT.Shop.Infrastructure.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Services;

    public class Basket : IBasketService
    {
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();

        public IEnumerable<BasketItem> BasketItems => this._basketItems;

        public string Key;

        public Basket(string key)
        {
            this.Key = key;
        }

        public void AddItem(Product product, int quantity)
        {
            var basketItem = this._basketItems.FirstOrDefault(i => i.Product.Id == product.Id);

            if (basketItem == null)
            {
                this._basketItems.Add(new BasketItem() { Product = product, Quantity = quantity });
            }
            else
            {
                basketItem.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            this._basketItems.RemoveAll(i => i.Product.Id == product.Id);
        }

        public decimal GetItemsSum()
        {
            return this._basketItems.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            this._basketItems.Clear();
        }

    }
}