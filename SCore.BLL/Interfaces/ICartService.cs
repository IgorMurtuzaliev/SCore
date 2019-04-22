using Microsoft.AspNetCore.Mvc;
using SCore.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCore.BLL.Interfaces
{
    public interface ICartService
    {
        void AddToCart(Cart cart, int? id);
        void RemoveFromCart(Cart cart, int? id);
    }
}
