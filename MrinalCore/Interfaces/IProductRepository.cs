using MrinalCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrinalCore.Interfaces
{
    public interface IProductRepository
    {
        List<Product> getProductList();
    }
}
