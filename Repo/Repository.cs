using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using test.Data;

namespace test.Repo {
    public class Repository<T> : IRepository<T> where T : BaseEntity {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        private DbSet<Hist> histEntities;
        private DbSet<Privilege> privEntities;
        string errMsg = string.Empty;
        public Repository (ApplicationContext context) {
            this.context = context;
            entities = context.Set<T> ();
            histEntities = context.Set<Hist> ();
            privEntities = context.Set<Privilege> ();
        }
        void IRepository<T>.Delete (T entity) {
            if (entity == null) {
                throw new ArgumentNullException ("entity");
            }
            entities.Remove (entity);
            context.SaveChanges ();
        }

        IEnumerable<T> IRepository<T>.GetAll () => entities.AsEnumerable ();

        T IRepository<T>.Get (int id) => entities.SingleOrDefault (m => m.Id == id);

        void IRepository<T>.Insert (T entity) {
            if (entity == null) {
                throw new ArgumentNullException ("entity");
            }
            entities.Add (entity);
            context.SaveChanges ();
        }

        void IRepository<T>.Remove (T entity) {
            if (entity == null) {
                throw new ArgumentNullException ("entity");
            }
            entities.Remove (entity);
        }

        void IRepository<T>.SaveChanges () {
            context.SaveChanges ();
        }

        void IRepository<T>.Update (T entity) {
            if (entity == null) {
                throw new ArgumentNullException ("entity");
            }
            context.SaveChanges ();
        }

        IEnumerable<Hist> IRepository<T>.GetHistByProduct (int productId) =>
            histEntities.Where (m => m.product.Id == productId);

        IEnumerable<Hist> IRepository<T>.GetHistByUser (int userID) =>
            histEntities.Where (m => m.user.Id == userID);

        IEnumerable<Privilege> IRepository<T>.GetPrivByTable (int tableId) =>
            privEntities.Where (m => m.table.Id == tableId);

        IEnumerable<Privilege> IRepository<T>.GetPrivByUser (int userID) =>
            privEntities.Where (m => m.user.Id == userID);
    }
}