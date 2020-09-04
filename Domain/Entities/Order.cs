using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Order : EntitieBase
    {
        public string OrderDescription { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();
        public decimal Money { get; private set; }
        protected Order() { }
        public Order(string description,Guid userId,IEnumerable<Product> products = null)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
    
            Id = Guid.NewGuid();
            OrderDescription = description;
            UserId = userId;
            if (products != null)
            {
                Products.AddRange(products);
                Money = GetMoneyFromProducts(products);
            }
            CreateTime = DateTime.Now;
            
        }

        private decimal GetMoneyFromProducts(IEnumerable<Product> products)
        {
            var money = products.Sum(x=>x.Coast);
         
            if (money > User.MoneyAmout)
                throw new ArgumentOutOfRangeException(nameof(money));
            return money;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            Products.Add(product);
            Money += GetCurrentSumOfMoney(product);
        }

        private decimal GetCurrentSumOfMoney(Product product)
        {
            return product.Coast;
        }
    }
}
