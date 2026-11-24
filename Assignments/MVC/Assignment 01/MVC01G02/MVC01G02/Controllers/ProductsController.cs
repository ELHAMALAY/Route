using Microsoft.AspNetCore.Mvc;
using MVC01G02.Models;

namespace MVC01G02.Controllers
{
    // CLR

    //[Route("[controller]")]
    public class ProductsController : Controller
    {
        //// Functions --> Methods --> Actions -> Endpoint -> Apis 


        //// BaseULR/Products/GetProductById

        //// Non-Static (Object Memeber Methods)
        //public Product GetProductById(int id)
        //{
        //    // Logic --> Connection To DB --> To Get Data

        //    return new Product() { Id = 1, Name = "Iphone 15 Pro Max", Price = 20 };
        //}


        // Actions : Public Non-Static (Object Memeber Function) Methods
        // Action Results : Built-in Datatype Used As Return Type For Actions


        // BaseURL/Products/GetProducts
        //[HttpPost]
        //public List<Product> GetProducts()
        //{
        //    // Logic

        //    return new List<Product>()
        //    {
        //        new Product(){Id = 1, Name = "P1", Price = 100},
        //        new Product(){Id = 2, Name = "P2", Price = 130},
        //        new Product(){Id = 3, Name = "P3", Price = 110},
        //    };
        //}


        //// BaseURL/Products/GetProductById
        //[HttpGet]
        //public Product GetProductById(int id)
        //{
        //    // Logic --> Connection To DB --> To Get Data
        //    return new Product() { Id = 1, Name = "Iphone 15 Pro Max", Price = 20 };
        //}


        // verb --> GET, POST, PUT, PATCH, DELETE




        [HttpGet]
        public JsonResult GetProducts()
        {
            // Logic
            return new JsonResult(new List<Product>()
            {
                new Product(){Id = 1, Name = "P1", Price = 100},
                new Product(){Id = 2, Name = "P2", Price = 130},
                new Product(){Id = 3, Name = "P3", Price = 110},
            });
        }



        // BaseURL/Products/Index
        [HttpGet]
        public ViewResult Index()
        {
            return new ViewResult(); // HTML Pages
        }



        [HttpGet] // BASEURL/Products/DownloadFile
        public FileContentResult DownloadFile()
        {
            var bytes = System.IO.File.ReadAllBytes("wwwroot/files/notes.txt");
            return new FileContentResult(bytes, "application/txt");
        }


        [HttpGet] // BASEURL/Products/RedirectToUrl
        public RedirectResult RedirectToUrl()
        {
            return Redirect("https://www.google.com");
        }



        [HttpGet]
        public RedirectToActionResult RedirectAction()
        {
            return RedirectToAction("RedirectToUrl", "Products", null);
        }


        // ActionResult
        public IActionResult Test(int id)
        {
            if (id == 1)
                return View();
            else if (id == 2)
                return Json(new Product() { Id = 1, Name = "Iphone 15 Pro Max", Price = 20 });
            else if (id == 3)
                return Redirect("https://www.facebook.com");
            else
                return View();
        }

    }
}
