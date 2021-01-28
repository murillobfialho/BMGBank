using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMGBank.Models;
using BMGBank.ModelsInterfaces;
using BMGBank.RepositoriesInterfaces;

namespace BMGBank.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        public Seller GetByCpf(string cpf)
        {
            return FakeDataBase.FakeDataBase.ListSeller.Find(x => x.Cpf == cpf);
        }

        public List<Seller> GetAll()
        {
            return FakeDataBase.FakeDataBase.ListSeller;
        }

        public bool Save(Seller seller)
        {
            FakeDataBase.FakeDataBase.ListSeller.Add(seller);
            return true;
        }
    }
}
