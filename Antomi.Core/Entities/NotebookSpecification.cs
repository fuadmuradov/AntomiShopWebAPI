﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.Entities
{
    public class NotebookSpecification
    {
        public int Id { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
        public string Graphics { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
