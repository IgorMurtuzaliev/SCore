using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Interfaces
{
    public interface IProductService
    {

        void Create(Product product);
        Product Get(int id);
    }
}
