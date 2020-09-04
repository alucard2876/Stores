using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Extentions
{
    public static class StringExtention
    {
        public static string HashPassword(this string str)
        {
            var hashPassword = 0;
            foreach (var item in str)
            {
                hashPassword += (int)item;
            }
            hashPassword = hashPassword * str.Length;
            return hashPassword.ToString() ;
        }
    }
}
