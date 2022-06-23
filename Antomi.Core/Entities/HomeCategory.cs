﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class HomeCategory
    {
        public int Id { get; set; }
        public string Image { get; set; }
      
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
