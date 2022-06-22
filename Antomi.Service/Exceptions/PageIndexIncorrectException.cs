using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Exceptions
{
    public class PageIndexIncorrectException:Exception
    {
        public PageIndexIncorrectException(string message):base(message)
        {
        }
    }
}
