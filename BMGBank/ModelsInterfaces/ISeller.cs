using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMGBank.Models;

namespace BMGBank.ModelsInterfaces
{
    public interface ISeller
    {
        public Seller GetByCpf(string cpf);

        public List<Seller> GetAll();

        public bool Save(Seller seller);
    }
}
