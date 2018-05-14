using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductsController : ApiController
    {
        //RESTfull controller => match f
        private IRepository Repository;
        public ProductsController()
        {
            Repository =  new ProductRepository();
        }

        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }
       
        public Product GetProduct(int id)
        {
            Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            //simplest validation
            if(result == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                return result;
            }
           
        }

        //Alternativa a metodos que devuelven objetos
        //public IHttpActionResult GetProduct(int id)
        //{
        //    Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
        //    if (result == null)
        //    {
        //        return (IHttpActionResult)BadRequest("Producto no encontrado");
        //    }
        //    else
        //    {
        //        return (IHttpActionResult)result;
        //    }
            
        //}

        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveProductAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles ="Adminitrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);    
        }
    }
}
