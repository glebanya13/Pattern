using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Lib
{
    public class StrWriter : IWriter
    {
        public string? Save(string? message)
        {
            if (message is null)
            {
                return "";
            }

            return message;
        }
    }
}
