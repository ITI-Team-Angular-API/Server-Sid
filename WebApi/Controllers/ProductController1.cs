using BL.AppServices;
using BL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.IO;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Product")]

    public class ProductController1 : ApiController
    {
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();
        // GET: Product

        [HttpGet]
        [Route("ViewProducs")]
        public List<ProductViewModel> Index()
        {
            //ViewBag.categories = categoryAppService.GetAllCategories();
            return (productAppService.GetAllProducts());
        }
        [HttpGet]
        [Route("ViewProducs")]
        public List<CategoryViewModel> create()
        {

            return categoryAppService.GetAllCategories();
            
        }
        /*
        [HttpPost]
        public ProductViewModel create(ProductViewModel productviewmodel, HttpPostedFileBase image)
        {
            var categories = categoryAppService.GetAllCategories();
            

            if (image != null)
            {
                if (image.ContentLength > 0)
                {
                    var filename = path.getfilename(image.FileName);
                    var path = path.combine(server.mappath("~/content/resources/images"), filename);
                    image.SaveAs(path);
                    productviewmodel.Image = filename;

                    productAppService.SaveNewProduct(productviewmodel);
                    // return redirecttoaction("index");
                    return productAppService.GetProduct(productviewmodel.Id);

                }
            }

           // return view(productviewmodel);
        }*/

        public ProductViewModel edit(int id)
        {
            List <ProductViewModel> product = productAppService.GetAllProducts();
            return productAppService.GetProduct(id);

        }

        //[HttpPost]
        //public ActionResult Edit(int id, ProductViewModel productViewModel, HttpPostedFileBase image)
        //{
        //    //if (ModelState.IsValid == false)
        //    //    return View(productViewModel);
        //    if (image.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(image.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Content/Resources/images"), fileName);
        //        image.SaveAs(path);
        //        productViewModel.Image = fileName;
        //    }
        //    productAppService.UpdateProduct(productViewModel);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int id)
        //{

        //    productAppService.DeleteProduct(id);
        //    return RedirectToAction("Index");
        //}
        [HttpDelete]
        [Route("DeleteProducs")]
        public void Delete(int id)
        {
            productAppService.DeleteProduct(id);
            //return Ok(); //can not refresh
        }
    }
}
