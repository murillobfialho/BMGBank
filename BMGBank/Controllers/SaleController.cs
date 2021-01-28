using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BMGBank.Models;
using BMGBank.ModelsInterfaces;

namespace BMGBank.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        [HttpGet]
        public IList<Sale> GetAllSales()
        {
            ISale saleData = new Sale();
            return saleData.GetAll();
        }
        
        [HttpGet("{id}")]
        public Sale GetSaleById(int id)
        {
            ISale saleData = new Sale();
            return saleData.Get(id);
        }

        private ContentResult getContentResult(string content, string contentType, int statusCode)
        {
            return new ContentResult
            {
                Content = content,
                ContentType = contentType,
                StatusCode = statusCode
            };
        }

        [HttpPost]
        public ContentResult RegisterSale([FromBody] Sale sale)
        {
            ISale s = new Sale();
            string error = "";
            var saveReturn = s.Save(sale, out error);

            if (saveReturn)
                return getContentResult("Operação efetuada com sucesso.", "text/plain", 200);
            else
                return getContentResult(error, "text/plain", 500);
        }
        
        [HttpPut("{id}")]
        public ContentResult UpdateSaleStatus(int id, [FromBody] Sale sale)
        {
            ISale s = new Sale();
            string error = "";
            var updateReturn = s.UpdateStatus(id, sale.Status, out error);

            if (updateReturn)
                return getContentResult("Operação efetuada com sucesso.", "text/plain", 200);
            else
                return getContentResult(error, "text/plain", 500);
        }
    }
}