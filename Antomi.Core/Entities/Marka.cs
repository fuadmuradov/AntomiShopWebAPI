﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Marka:BaseEntity
    {
        public string Name { get; set; }
        public List<SubcategoryToMarka> SubcategoryToMarkas { get; set; }
    }
}
