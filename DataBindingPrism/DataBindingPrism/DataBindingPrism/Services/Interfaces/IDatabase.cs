using DataBinding.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBindingPrism.Services.Interfaces
{
    public interface IDatabase
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetLatestProduct();
        Task<int> DeleteProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<List<Product>> GetSortedData();
    }
}
