using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAccess
{
    internal class MessageBuilder
    {
        public string Build(string message,string nameofType,string nameofMethod)
        {
            var builder = new StringBuilder();

            builder.Append(message);
            builder.Append(" in ");
            builder.Append(nameofType);
            builder.Append(" ");
            builder.Append(nameofMethod);
            return builder.ToString();
        }
    }
}
