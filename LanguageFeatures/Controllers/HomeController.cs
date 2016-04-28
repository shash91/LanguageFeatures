using System.Linq;
using System.Text;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        /*    public ViewResult AutoProperty()
            {
                //create a new product object
                Product myProduct = new Product();
                //Setting property value
                myProduct.Name = "Kayak";
                myProduct.ProductId = 10;
                //getting the property
                string productname = myProduct.Name;
                string productid = Convert.ToString(myProduct.ProductId);
                //generate the view
                return View("Result", (object)string.Format("Product Name:{0}", productname,"Product Id:{0:2}",productid));

            }*/
        /* public ViewResult CreateProduct()
         {
             Product myProduct = new Product
             {
                 ProductId = 10,
                 Name = "Kayak",
                 Description = "A boat ",
                 Price = 275M,
                 Category = "WaterSports"
             };
             return View("Result", (object)string.Format("Category:{0}", myProduct.Category));
         }*/
        /* public ViewResult CreateCollection()
         {
             string[] stringArray = { "apple", "orange", "plum" };
             List<int> intList = new List<int> { 10, 20, 30, 40 };
             Dictionary<string, int> myDict = new Dictionary<string, int>
             {
                 {"apple",10 }, {"orange",20 }, {"plum",30 }
             };
             return View("Result", (object)stringArray[1]);
         }*/
        /* public ViewResult UseExtension()
         {
             ShoppingCart cart = new ShoppingCart
             {
                 Products = new List<Product>
                 {
                     new Product {Name="Kayak",Price=275M },
                     new Product { Name="LifeJacket",Price=48.95M},
                     new Product {Name="Soccer ball",Price=19.50M },
                     new Product {Name="Corner flag",Price=34.95M }
                 }
             };
             decimal cartTotal = cart.TotalPrices();
             return View("Result", (object)String.Format("Total:{0:c}", cartTotal));
         }*/
        /*  public ViewResult UseExtensionEnumerable()
          {
              IEnumerable<Product> products = new ShoppingCart
              {
                  Products = new List<Product>
                  {
                     new Product {Name="Kayak",Price=275M },
                      new Product { Name="LifeJacket",Price=48.95M},
                      new Product {Name="Soccer ball",Price=19.50M },
                      new Product {Name="Corner flag",Price=34.95M }
                  }
              };
              Product[] productArray={
                  new Product { Name = "Kayak", Price = 275M },
                      new Product { Name = "LifeJacket", Price = 48.95M },
                      new Product { Name = "Soccer ball", Price = 19.50M },
                      new Product { Name = "Corner flag", Price = 34.95M }
              };
              decimal carttot = products.TotalPrices();
              decimal arraytot = products.TotalPrices();

              return View("Result", (object)string.Format("Cart Total:{0},Array Total:{1}", carttot, arraytot));
          }*/

        /*  public ViewResult UseFilterExtensionMethod()
          {
              IEnumerable<Product> products = new ShoppingCart
              {
                  Products = new List<Product>
                  {
                      new Product {Name="kayak", Category="Watersports",Price=275M },
                      new Product { Name = "LifeJacket", Category = "Watersports", Price = 48.95M },
                      new Product {Name="SoccerBall",Category="soccer",Price=19.50M },
                      new Product {Name="Corner Flag",Category="soccer",Price=34.95M }
                  }
              };

              decimal total = 0;
              foreach (Product prod in products.Filter(prod=>prod.Category=="soccer" || prod.Price>20))
              {
                  total += prod.Price;
              }
              return View("Result", (object)string.Format("Total:{0}", total));
          }*/
        /* public ViewResult CreateAnonArray()
         {
             var oddsAndEnds = new[]
             {
                 new {Name="MVC",Category="Pattern"},
                 new {Name="Hat",Category="clothing"},
                 new {Name="Apple",Category="Fruit"}
             };
             StringBuilder result = new StringBuilder();
             foreach(var item in oddsAndEnds)
             {
                 result.Append(item.Name).Append(" ");
             }
             return View("Result", (object)result.ToString());
         }*/

        //finding prices without linq 
        /* public ViewResult FindProducts()
         {
             Product[] products =
             {
                new Product {Name="kayak", Category="Watersports",Price=275M },
                     new Product { Name = "LifeJacket", Category = "Watersports", Price = 48.95M },
                     new Product {Name="SoccerBall",Category="soccer",Price=19.50M },
                     new Product {Name="Corner Flag",Category="soccer",Price=34.95M }
             };
             Product[] foundProducts = new Product[3];
             Array.Sort(products, (item1, item2) =>
              { return Comparer<decimal>.Default.Compare(item1.Price, item2.Price); }
             );
             Array.Copy(products, foundProducts, 3);
             StringBuilder result = new StringBuilder();
             foreach(Product p in foundProducts)
             {
                 result.AppendFormat("Price:{0}", p.Price);
             }
             return View("Result", (object)result.ToString());
         }*/

        //Finding prices with Linq
        /*ublic ViewResult FindProducts()
         {
             Product[] products =
             {
                 new Product { Name = "kayak", Category = "Watersports", Price = 275M },
                 new Product { Name = "LifeJacket", Category = "Watersports", Price = 48.95M },
                 new Product { Name = "SoccerBall", Category = "soccer", Price = 19.50M },
                 new Product { Name = "Corner Flag", Category = "soccer", Price = 34.95M }
             };

             var foundProducts = from match in products
                                 orderby match.Price descending
                                 select new
                                 {
                                     match.Name,
                                     match.Price
                                 };
             int count = 0;
             StringBuilder result = new StringBuilder();
             foreach(var p in foundProducts)
             {
                 result.AppendFormat("Price:{0}", p.Price);
                 if(++count==3)
                 {
                     break;
                 }
             }
             return View("Result", (object)result.ToString());
         }*/
        //Using Linq Dot Notation
        public ViewResult FindProducts()
        {
            Product[] products =
           {
                new Product { Name = "kayak", Category = "Watersports", Price = 275M },
                new Product { Name = "LifeJacket", Category = "Watersports", Price = 48.95M },
                new Product { Name = "SoccerBall", Category = "soccer", Price = 19.50M },
                new Product { Name = "Corner Flag", Category = "soccer", Price = 34.95M }
            };
            var foundProducts = products.OrderByDescending(e => e.Price).Take(3)
                .Select(e => new { e.Name, e.Price });
            products[2] = new Product { Name = "stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price:{0}", p.Price);


    }
            return View("Result", (object)result.ToString());
        }

        public ViewResult sumProducts()
        {
            Product[] products =
          {
                new Product { Name = "kayak", Category = "Watersports", Price = 275M },
                new Product { Name = "LifeJacket", Category = "Watersports", Price = 48.95M },
                new Product { Name = "SoccerBall", Category = "soccer", Price = 19.50M },
                new Product { Name = "Corner Flag", Category = "soccer", Price = 34.95M }
            };
            var results = products.Sum(e => e.Price);

            products[2] = new Product { Name = "Stadium", Price = 79500M };

            return View("Result", (object)string.Format("Sum:{0}", results));
        }
    }
}