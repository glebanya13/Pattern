using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class DecRSA : Decorator
    {
        public DecRSA(IWriter writer) : base(writer) { }

        public override string? Save(string? message)
        {
            int delPos = message!.IndexOf(Constant.Delimiter);
            string oldMessage = message!.Substring(0, delPos);
            byte[] xsbhc = Convert.FromBase64String(message!.Substring(delPos + 1));

            using (RSACryptoServiceProvider rsa = new())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                rsa.FromXmlString(publicKey);
                var encryptedHash = rsa.Encrypt(xsbhc, RSAEncryptionPadding.Pkcs1);
                return base.Save(string.Format(
                    "{0}{1}{2}{3}{4}",
                    oldMessage, Constant.Delimiter, Convert.ToBase64String(encryptedHash), Constant.Delimiter, privateKey
                ));
            }
        }
    }
}
