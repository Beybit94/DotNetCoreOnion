using System.Collections.Generic;
using test.Data;

namespace test.Service
{
    public interface ITableService
    {
        IEnumerable<G_Table> GetG_Tables ();
        G_Table GetG_Table (int id);
        void InsertG_Table (G_Table privilege);
        void UpdateG_Table (G_Table privilege);
        void DeleteG_Table (int id); 
    }
}