﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Fullname { get; set; }
        public string Jobname { get; set; }
        public string Description { get; set; }
    }
}
