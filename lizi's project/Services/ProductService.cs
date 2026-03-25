using lizi_s_project.Dtos;
using lizi_s_project.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace lizi_s_project.Services
{
    public class ProductService
    {
        //public List<AllProductsDto> GetAllProducts()
        //{
        //    List<AllProductsDto> AllProducts = products.Select(item => new AllProductsDto { Name = item.Name, Price = item.Price }).ToList();

        //}

        private int number {get;set;}
        public ProductService()
        {
            Random random1= new Random();
            number = random1.Next(0,100);
        }
        public string TestFunction()
        {
            return "Hello World";
        }

        public int TestFunction1()
        {
            return number;
        }

    }
}
