﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Service.Exceptions
{
    public class RecordDublicateException:Exception
    {
        public RecordDublicateException(string message) : base(message)
        {

        }
    }
}
