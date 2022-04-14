using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product238.Models;

namespace Product238.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>();
        // GET: Product
        /*public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult ListProducts()
        {
         if(products.Count() == 0)
            {
                products.Add(new Product(1, "Yamaha C40", "Nhạc Cụ", 4200000, "/Content/images/guitar1.jpg"));
                products.Add(new Product(2, "Yamaha GS23", "Nhạc Cụ", 10500000, "/Content/images/guitar2.jpg"));
                products.Add(new Product(3, "Yamaha F2", "Nhạc Cụ", 8750000, "/Content/images/guitar3.jpg"));
                products.Add(new Product(4, "Yamaha Silent 350C", "Nhạc Cụ", 1905000, "/Content/images/guitar4.jpg"));
                products.Add(new Product(5, "Guitar Mini Yamaha G10", "Nhạc Cụ", 5200000, "/Content/images/guitar5.jpeg"));  
            }
            return View(products);
        }
        public ActionResult EditProduct(int id)
        {
            Product product = new Product();
            foreach (Product pd in products)
            {
                if (pd.Id == id)
                {
                    product = pd;
                    break;
                }
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("EditProduct")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook(int? id, string pName, string pType, double pPrice, string imgCover)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Product pd in products)
            {
                if (id == pd.Id)
                {
                    pd.PName = pName;
                    pd.PType = pType;
                    pd.PPrice = pPrice;
                    pd.ImgCover = imgCover;
                    break;
                }
            }
            // Tạo dữ liệu cho view với ViewBag
            ViewBag.Products = products;
            return View("ListProducts", products);
        }

        /*----------------Delete---------------*/
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = new Product();
            foreach (var pd in products)
            {
                if (pd.Id == id)
                {
                    product = pd;
                    break;
                }
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductId(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = new Product();
            foreach (Product pd in products)
            {
                if (pd.Id == id)
                {
                    product = pd;
                    break;
                }
            }
            products.Remove(product);
            return View("ListProducts", products);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost, ActionName("CreateProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "id, PName, PType, PPrice, ImgCover")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Thêm sách mới
                    products.Add(product);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Lỗi ghi dữ liệu");
            }
            return View("ListProducts", products);
        }

        /*-------------Detail--------------*/

        public ActionResult DetailProduct(int id)
        {
            Product product = new Product();
            foreach (Product pd in products)
            {
                if (pd.Id == id)
                {
                    product = pd;
                    break;
                }
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }





    }
}