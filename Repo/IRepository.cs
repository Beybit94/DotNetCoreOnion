using System.Collections.Generic; 
using test.Data;

namespace test.Repo
{
    public interface IRepository<T> where T:BaseEntity
    {
         IEnumerable<T> GetAll();
         T Get(int id);
         void Insert(T entity);  
         void Update(T entity);  
         void Delete(T entity);  
         void Remove(T entity);  
         void SaveChanges();  

         IEnumerable<Hist> GetHistByProduct (int productId);
         IEnumerable<Hist> GetHistByUser (int userID);
         IEnumerable<Privilege> GetPrivByTable (int tableId);
         IEnumerable<Privilege> GetPrivByUser (int userID);
    }
}