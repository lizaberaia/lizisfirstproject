//using Microsoft.AspNetCore.Mvc;

//namespace lizi_s_project.Controllers
//{
//    [ApiController]
//    [Route("/api/products")]
//    public class WeatherForecastController : ControllerBase
//    {
       

//        public List<Product> products = new List<Product>()
//        { 
//            new Product(1,"iphone 14",2600),
//              new Product(2,"iphone 13",2500),
//                new Product(3,"iphone 15",2300),
//                  new Product(4,"iphone 16",2900),
//                    new Product(5,"iphone 17",3000),
//                      new Product(6,"iphone 17 Pro",35000),
//                        new Product(7,"iphone 18",3800),
//        };


//        public WeatherForecastController()
//        {

//        }

//        [HttpGet] 
//        public ActionResult GetProduct()
//        {
            
//            return Ok( products);
//        }

//        [HttpPost]
//        public ActionResult AddProduct(int id, string name, double price)
//        {
//            products.Add(new Product(id, name, price));
//            return Ok(products);
//        }
//    }


//}
