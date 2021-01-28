using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMGBank.Models;

namespace BMGBank.ModelsInterfaces
{
    public interface ISale
    {
        public bool Save(Sale sale, out string errorMessage);

        public bool UpdateStatus(int saleId, string newStatus, out string errorMessage);

        public Sale Get(int id);

        public List<Sale> GetAll();
    }
}
