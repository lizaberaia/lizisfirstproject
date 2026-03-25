using lizi_s_project.Dtos;
using lizi_s_project.Models;
using lizi_s_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace lizi_s_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        public ProductService productService;

        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }
        public List<Product> products = new List<Product>()
        {
            new Product(1,"iphone 14",2600),
              new Product(2,"iphone 13",2500),
                new Product(3,"iphone 15",2300),
                  new Product(4,"iphone 16",2900),
                    new Product(5,"iphone 17",3000),
                      new Product(6,"iphone 17 Pro",3500),
                        new Product(7,"iphone 18",3800),
        };

        [HttpGet]
        
        public ActionResult<AllProductsDto> GetProducts()
        {
            // თუ არ გვინდა რომ ყველა პარამეტრი გადავცეთ , ვაკეთებთ სელექთს

           List<AllProductsDto> AllProducts = products.Select(item=>new AllProductsDto { Name = item.Name, Price = item.Price }).ToList();
           return Ok(AllProducts);
        }
        // ასევე შეგვიძლია დავწეროთ 

        //public ActionResult<List<AllProductsDto>> GetProducts()
        //{
        //    return Ok(AllProducts);
        //}


        [HttpGet("test")]

        public ActionResult Test()
        {
            string result = productService.TestFunction();
            return Ok(result);
        }

        [HttpGet("test1")]

        public ActionResult Test1()
        {
            int result = productService.TestFunction1();
            return Ok(result);
        }

        [HttpGet("{id}")] // tu gvinda erti romelime konkretuli monacemis camogheba, fronti  mogvcems IDs da camovigheb sasruveb monacems

        public ActionResult GetProcuctById(int id)
        {
            var result = products.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound("სამწუხაროდ,ასეთი პროდუქტი არ იძებნება");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("Name")]

        public ActionResult GetProductByName(string name)
        {
            var result = products.FirstOrDefault(x => x.Name == name);
            if (result == null)
            {
                return NotFound("სამწუხაროდ, არსებული სახელით მონაცემი ვერ მოიძებნა");
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("/AddProduct")]
        [HttpPost]


        //არსებობს FromBody და FromQuery, უმჯობესია დავუწერროთ ხოლმე რომ FromBody-დან წამოიღოს
        public ActionResult AddProduct([FromBody] AddProductDto AddProducts)
        {
            //if (Products.Id <= 0)
            //{
            //    return BadRequest("invalid Id");
            //}
            if (AddProducts.Name == "")
            {
                return BadRequest("invalid name");
            }
            if (AddProducts.Price <= 0)
            {
                return BadRequest("invalid Price");
            }

            int MaxId = products.Max(item => item.Id);

            products.Add(new Product(MaxId+1,AddProducts.Name, AddProducts.Price));
            return Ok(new
            {
                text = "პროდუქტი წარმატებით დაემატა",
                product = products
            });

            //var result = products.FirstOrDefault(item => item.Id == Products.Id);
            //if (result != null)
            //{
            //    return BadRequest(new
            //    {
            //        text = "ასეთ პროდუქტი უკვე არასებობს",
            //        product = result
            //    });
            //}
        }

        [Route("/ChangeProduct")]
        [HttpPut]
         
        public ActionResult ChangeProduct(int id, double price)
        {
            var result = products.FirstOrDefault(item => item.Id == id);

            if (result == null)
            {
                return NotFound("ასეთი პროდუქტი არ არსებობს");
            }
            else
            {
                if (price > 0)
                {
                    result.Price = price;
                    return Ok(new
                    {
                        text = "პროდუქტი წარმატებით შეიცვალა",
                        products = products
                    });
                }
                else
                {
                    return BadRequest("ფასი არასწორად არის ჩაწერილი");
                }
            }

        }

        [HttpDelete("{id}")]

        public ActionResult DeleteProduct(int id)
        {
            var result = products.FirstOrDefault(item => item.Id == id);
            if (result == null)
            {
                return NotFound("ასეთი პროდუქტი არ არსებობს");
            }
            else
            {
                products.Remove(result);
                return Ok(new
                {
                    text = "წარმატებით წაიშალა პროდუქტი",
                    products = products
                });
            }
        }

        //ძირითადი კლასები რაც იქმნეა უნდა ჩაიყაროს Models folder-ში
        //dto  არის ისეთი კლასი, რომელიც გვეხმარება რექვესტებთან სამუშაოდ, მონაცემების დასაბრუნებლად

        /*
         * კონტროლერებში უნდა იყოს მცირედი ინფორმაციაა მოცემული, ხოლო მნიშვნელოვანი სამუშაოები რაც უნდა შესრულდეეს ,
         * ისინი განთავსებული უნდა იყოს Service-ს ფაილში
        */

        
    }
}