using System.Collections.Generic;
using test.Data;
using test.Repo;
using test.Service;

namespace test.Service {
    public class ProductService : IProductService {
        private IRepository<Product> productRepository;
        private IRepository<Hist> histRepository;
        private IRepository<Privilege> privRepository;

        public ProductService (IRepository<Product> productRepository,IRepository<Hist> histRepository,
                            IRepository<Privilege> privRepository) {

            this.productRepository = productRepository;
            this.histRepository=histRepository;
            this.privRepository=privRepository;
        }

        public IEnumerable<Product> GetProducts () {
            return productRepository.GetAll ();
        }

        public Product GetProduct (int id) {
            return productRepository.Get (id);
        }

        public void InsertProduct (Product product) {
            productRepository.Insert (product);
        }
        public void UpdateProduct (Product product) {
            productRepository.Update (product);
        }

        public void DeleteProduct (int id) {

            foreach (var item in productRepository.GetHistByProduct(id)) {
               histRepository.Remove(item);
            }

            Product product = GetProduct (id);
            productRepository.Remove (product);
            productRepository.SaveChanges ();
        }
    }
}