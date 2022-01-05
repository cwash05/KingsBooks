using KingsBooks.Models.DomainModels;
using KingsBooks.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Models.ExtensionMethods
{
    public static class CartItemListExtension
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO
            {
                BookId = ci.Book.BookId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
