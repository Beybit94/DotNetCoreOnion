using System.Collections.Generic;
using test.Data;

namespace test.Service
{
    public interface IHistService
    {
        IEnumerable<Hist> GetHists ();
        Hist GetHist (int id);
        void InsertHist (Hist hist);
        void UpdateHist (Hist hist);
        void DeleteHist (int id); 
    }
}