using System.Collections.Generic;
using test.Data;
using test.Repo;
using test.Service;

namespace test.Service {
    public class HistService : IHistService {
        private IRepository<Hist> histRepository;

        public HistService (IRepository<Hist> histRepository) {
            this.histRepository = histRepository;
        }

        public IEnumerable<Hist> GetHists () {
            return histRepository.GetAll ();
        }

        public Hist GetHist (int id) {
            return histRepository.Get (id);
        }

        public void InsertHist (Hist hist) {
            histRepository.Insert (hist);
        }
        public void UpdateHist (Hist hist) {
            histRepository.Update (hist);
        }

        public void DeleteHist (int id) {
            Hist hist = GetHist (id);
            histRepository.Remove (hist);
            histRepository.SaveChanges ();
        }
    }
}