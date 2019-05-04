using Microsoft.AspNetCore.Mvc;
using SCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCore.BLL.Interfaces
{
    public interface ISearchService
    {
        List<Order> FindByDate(DateTime? from, DateTime? to);
        List<Order> FindByUser(string search);
    }
}
