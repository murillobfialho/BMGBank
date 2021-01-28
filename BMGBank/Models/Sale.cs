using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BMGBank.ModelsInterfaces;
using BMGBank.RepositoriesInterfaces;
using BMGBank.Repositories;

namespace BMGBank.Models
{
    public class Sale : ISale
    {
        public int Id { get; set; }
        
        [MaxLength(50,ErrorMessage = "O campo status suporta até {1} caracteres")]
        public string Status { get; set; }

        public DateTime Date { get; set; }

        public string SaleIdentifier { get; set; }

        public Seller Seller { get; set; }
        
        public IList<Product> ProductList { get; set; }
        
        private int GetMaxSaleId()
        {
            ISaleRepository repository = new SaleRepository();
            var sales = repository.GetAll();

            if (sales.Count == 0)
                return 1;
            else
            {
                int maxNumber = 0;
                foreach (var item in sales)
                {
                    if (item.Id > maxNumber)
                        maxNumber = item.Id;
                }

                return maxNumber+1;
            }
        }

        public bool Save(Sale sale, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                if (sale.ProductList is null || sale.ProductList.Count == 0)
                {
                    errorMessage = "É necessário registrar ao menos 1 item para cadastrar uma venda.";
                    return false;
                }    

                ISeller s = new Seller();
                var seller = s.GetByCpf(sale.Seller.Cpf);

                if (seller is null)
                    s.Save(sale.Seller);
                else
                    sale.Seller = seller;

                sale.Id = GetMaxSaleId();
                sale.SaleIdentifier = System.Guid.NewGuid().ToString();
                sale.Status = Utils.SaleStatus["AGUARDANDO_PAGAMENTO"];

                ISaleRepository repository = new SaleRepository();
                return repository.Save(sale);
            }
            catch
            {
                errorMessage = "Erro ao tentar salvar venda.";
                return false;
            }
        }

        public bool IsValidChangeStatus(string oldStatus, string newStatus)
        {
            if(string.IsNullOrEmpty(newStatus))
                return false;

            if (oldStatus == Utils.SaleStatus["AGUARDANDO_PAGAMENTO"])
            {
                if (newStatus == Utils.SaleStatus["PAGAMENTO_APROVADO"] || newStatus == Utils.SaleStatus["CANCELADA"])
                    return true;
                else
                    return false;
            }
            
            if (oldStatus == Utils.SaleStatus["PAGAMENTO_APROVADO"])
            {
                if (newStatus == Utils.SaleStatus["ENVIADO_PARA_TRANSPORTADORA"] || newStatus == Utils.SaleStatus["CANCELADA"])
                    return true;
                else
                    return false;
            }
            
            if (oldStatus == Utils.SaleStatus["ENVIADO_PARA_TRANSPORTADORA"])
            {
                if (newStatus == Utils.SaleStatus["ENTREGUE"])
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool UpdateStatus(int saleId, string newStatus, out string errorMessage)
        {
            string auxNewStatus = newStatus.Trim().ToUpper();
            errorMessage = null;

            try
            {
                ISale s = new Sale();
                var sale = s.Get(saleId);

                if (sale is null)
                {
                    errorMessage = "Venda não encontrada.";
                    return false;
                }

                if (!IsValidChangeStatus(sale.Status, auxNewStatus))
                {
                    errorMessage = "Alteração de Status não permitida.";
                    return false;
                }

                ISaleRepository repository = new SaleRepository();
                return repository.UpdateStatus(sale, auxNewStatus);
            }
            catch
            {
                errorMessage = "Erro ao tentar atualizar status de venda.";
                return false;
            }
        }

        public Sale Get(int id)
        {
            ISaleRepository repository = new SaleRepository();
            return repository.Get(id);
        }

        public List<Sale> GetAll()
        {
            ISaleRepository repository = new SaleRepository();
            return repository.GetAll();
        }
    }
}
