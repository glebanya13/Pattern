using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class DecMD5 : Decorator
    {
        public DecMD5(IWriter writer) : base(writer) { }

        public override string? Save(string? message)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(message!);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return writer!.Save(message + Constant.Delimiter + Convert.ToBase64String(hashBytes));
            }
        }
    }
}
