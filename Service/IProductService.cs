using System.Collections.Generic;
using test.Data;

namespace test.Service {
    public interface IProductService {
        IEnumerable<Product> GetProducts ();
        Product GetProduct (int id);
        void InsertProduct (Product product);
        void UpdateProduct (Product product);
        void DeleteProduct (int id);
    }
}