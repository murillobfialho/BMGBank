using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMGBank.FakeDataBase;
using BMGBank.Models;
using BMGBank.RepositoriesInterfaces;

namespace BMGBank.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public bool Save(Sale sale)
        {
            FakeDataBase.FakeDataBase.ListSale.Add(sale);
            return true;
        }

        public bool UpdateStatus(Sale sale, string newStatus) 
        {
            var oldSale = FakeDataBase.FakeDataBase.ListSale.Find(x => x.Id == sale.Id);
            oldSale.Status = newStatus;
            return true;
        }

        public Sale Get(int id) 
        {
            return FakeDataBase.FakeDataBase.ListSale.Find(x => x.Id == id);
        }

        public List<Sale> GetAll()
        {
            return FakeDataBase.FakeDataBase.ListSale;
        }
    }
}
