using System.Collections.Generic;
using test.Data;

namespace test.Service
{
    public interface IPrivilegeService
    {
        IEnumerable<Privilege> GetPrivileges ();
        Privilege GetPrivilege (int id);
        void InsertPrivilege (Privilege privilege);
        void UpdatePrivilege (Privilege privilege);
        void DeletePrivilege (int id); 
    }
}