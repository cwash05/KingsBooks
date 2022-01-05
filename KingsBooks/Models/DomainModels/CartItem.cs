using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsBooks.Models.DTOs;
using Newtonsoft.Json;

namespace KingsBooks.Models.DomainModels
{
    public class CartItem
    {
        public BookDTO Book { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Book.Price * Quantity;
    }
}
