﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class ProductSearchResult
    {
        public List<Product> Products { get; set; } = new();
        public int Pages { get; set; }
        public int Current { get; set; }
    }
}
