﻿using KingsBooks.Models.DomainModels;
using KingsBooks.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Models.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal {get; set; }
        public RouteDictionary  BookGridRoute { get; set; }

    }
}
