using System;

namespace Domain.Entities
{
    public class User : EntitieBase
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthday { get; private set; }
        public decimal MoneyAmout { get; private set; }
        protected User() { }

        public User(string userName,string password, DateTime birthday)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            Birthday = birthday;
            CreateTime = DateTime.Now;
        }

        public void UpdateUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            UserName = userName;
            LastUpdateTime = DateTime.Now;
        }

        public void UpdatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            Password = password;
            LastUpdateTime = DateTime.Now;
        }

        public void UpdateAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            MoneyAmout = amount;

        }

    }
}
