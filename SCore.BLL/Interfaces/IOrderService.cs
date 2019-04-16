using SCore.WEB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderViewModel orderVM);
    }
}
