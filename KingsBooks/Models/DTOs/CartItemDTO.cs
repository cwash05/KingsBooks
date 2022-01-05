using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Models.DTOs
{
    public class CartItemDTO
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}
