using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMGBank.Models;

namespace BMGBank.RepositoriesInterfaces
{
    public interface ISaleRepository
    {
        public bool Save(Sale sale);

        public bool UpdateStatus(Sale sale, string newStatus);
        
        public Sale Get(int id);

        public List<Sale> GetAll();
    }
}
