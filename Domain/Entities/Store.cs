using System;
using System.Collections.Generic;


namespace Domain.Entities
{
    public class Store : EntitieBase
    {
        public string StoreTitle { get; private set; }
        public ICollection<Product> _products = new List<Product>();
        public IEnumerable<Product> Products => _products;
        protected Store() { }
        public Store(string storeTitle)
        {
            if (string.IsNullOrEmpty(storeTitle))
                throw new ArgumentNullException(storeTitle);
            Id = Guid.NewGuid();
            StoreTitle = storeTitle;
            CreateTime = DateTime.Now;
        }
        public void UpdateStreTitle(string storeTitle)
        {
            if (string.IsNullOrEmpty(storeTitle))
                throw new ArgumentNullException(nameof(storeTitle));
            StoreTitle = storeTitle;
            LastUpdateTime = DateTime.Now;
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
    }
}
