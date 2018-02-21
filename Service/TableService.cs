using System.Collections.Generic;
using test.Data;
using test.Repo;
using test.Service;

namespace test.Service {
    public class TableService : ITableService {
        private IRepository<G_Table> tableRepository;

        public TableService (IRepository<G_Table> tableRepository) {
            this.tableRepository = tableRepository;
        }

        public IEnumerable<G_Table> GetG_Tables () {
            return tableRepository.GetAll ();
        }

        public G_Table GetG_Table (int id) {
            return tableRepository.Get (id);
        }

        public void InsertG_Table (G_Table table) {
            tableRepository.Insert (table);
        }
        public void UpdateG_Table (G_Table table) {
            tableRepository.Update (table);
        }

        public void DeleteG_Table (int id) {
            G_Table table = GetG_Table (id);
            tableRepository.Remove (table);
            tableRepository.SaveChanges ();
        }
    }
}