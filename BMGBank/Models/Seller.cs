using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BMGBank.ModelsInterfaces;
using BMGBank.RepositoriesInterfaces;
using BMGBank.Repositories;

namespace BMGBank.Models
{
    public class Seller : ISeller
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "O campo CPF suporta até {1} caracteres")]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O campo Name suporta até {1} caracteres")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "O campo Email suporta até {1} caracteres")]
        public string Email { get; set; }

        [MaxLength(30, ErrorMessage = "O campo Phone suporta até {1} caracteres")]
        public string Phone { get; set; }

        public Seller GetByCpf(string cpf)
        {
            ISellerRepository repository = new SellerRepository();
            return repository.GetByCpf(cpf);
        }

        public List<Seller> GetAll() 
        {
            ISellerRepository repository = new SellerRepository();
            return repository.GetAll();
        }

        private int GetMaxSellerId()
        {
            ISellerRepository repository = new SellerRepository();
            var sellers = repository.GetAll();

            if (sellers.Count == 0)
                return 1;
            else
            {
                int maxNumber = 0;
                foreach (var item in sellers)
                {
                    if (item.Id > maxNumber)
                        maxNumber = item.Id;
                }

                return maxNumber+1;
            }
        }

        public bool Save(Seller seller) 
        {
            seller.Id = GetMaxSellerId();

            ISellerRepository repository = new SellerRepository();
            return repository.Save(seller);
        }
    }
}
