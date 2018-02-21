using System.Collections.Generic;
using test.Data;
using test.Repo;
using test.Service;

namespace test.Service {
    public class UserService : IUserService {
        private IRepository<User> userRepository;
        private IRepository<Hist> histRepository;
        private IRepository<Privilege> privRepository;

        public UserService (IRepository<User> userRepository,IRepository<Hist> histRepository,
                            IRepository<Privilege> privRepository) {

            this.userRepository = userRepository;
            this.histRepository=histRepository;
            this.privRepository=privRepository;
        }

        public IEnumerable<User> GetUsers () {
            return userRepository.GetAll ();
        }

        public User GetUser (int id) {
            return userRepository.Get (id);
        }

        public void InsertUser (User user) {
            userRepository.Insert (user);
        }
        public void UpdateUser (User user) {
            userRepository.Update (user);
        }

        public void DeleteUser (int id) {

            foreach (var item in userRepository.GetHistByUser(id)) {
               histRepository.Remove(item);
            }

            foreach (var item in userRepository.GetPrivByUser(id)) {
               privRepository.Remove(item);
            }

            User user = GetUser (id);
            userRepository.Remove (user);
            userRepository.SaveChanges ();
        }
    }
}