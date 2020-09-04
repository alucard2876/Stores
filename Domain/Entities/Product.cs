using System;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Product : EntitieBase
    {
        public string ProductTitle { get; private set; }
        public string SmallDescription { get; private set; }
        public string MainDescription { get; private set; }
        public decimal Coast { get; private set; }
        public Guid StoreId { get; private set; }
        public virtual Store Store { get; private set; }
        protected Product() { }

        public Product(string productTitle,string description,decimal coast,Guid storeId)
        {
            if (string.IsNullOrEmpty(productTitle))
                throw new ArgumentNullException(nameof(productTitle));
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            if (coast <= 0)
                throw new ArgumentOutOfRangeException(nameof(coast));

            Id = Guid.NewGuid();
            ProductTitle = productTitle;
            MainDescription = description;
            SmallDescription = GetSmallDescription(description);
            Coast = coast;
            CreateTime = DateTime.Now;
            StoreId = storeId;
        }
        public void UpdateProductTitle(string productTitle)
        {
            if (string.IsNullOrEmpty(productTitle))
                throw new ArgumentNullException(nameof(productTitle));
            ProductTitle = productTitle;
            LastUpdateTime = DateTime.Now;
        }
        public void UpdateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            MainDescription = description;
            SmallDescription = GetSmallDescription(description);
            LastUpdateTime = DateTime.Now;
        }
        public void UpdateCoast(decimal coast)
        {
            if (coast <= 0)
                throw new ArgumentOutOfRangeException(nameof(coast));
            Coast = coast;
            LastUpdateTime = DateTime.Now;
        }
        private string GetSmallDescription(string description)
        {
            var result = new StringBuilder();
            foreach (var item in description.Take(50))
            {
                result.Append(item);
            }
            return result.ToString();
        }
    }
}
