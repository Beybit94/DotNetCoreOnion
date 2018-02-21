using System.Collections.Generic;
using test.Data;
using test.Repo;
using test.Service;

namespace test.Service {
    public class PrivilegeService : IPrivilegeService {
        private IRepository<Privilege> privilegeRepository;

        public PrivilegeService (IRepository<Privilege> privilegeRepository) {
            this.privilegeRepository = privilegeRepository;
        }

        public IEnumerable<Privilege> GetPrivileges () {
            return privilegeRepository.GetAll ();
        }

        public Privilege GetPrivilege (int id) {
            return privilegeRepository.Get (id);
        }

        public void InsertPrivilege (Privilege privilege) {
            privilegeRepository.Insert (privilege);
        }
        public void UpdatePrivilege (Privilege privilege) {
            privilegeRepository.Update (privilege);
        }

        public void DeletePrivilege (int id) {
            Privilege privilege = GetPrivilege (id);
            privilegeRepository.Remove (privilege);
            privilegeRepository.SaveChanges ();
        }
    }
}