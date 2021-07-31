using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using BL.AppServices;
using BL.ViewModel;
using DAL;

namespace WebApi.Controllers
{
    // [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();
        CategoryAppService categoryAppService = new CategoryAppService();
        ProductAppService productAppService = new ProductAppService();

        public IHttpActionResult Index()
        {
            List<CategoryViewModel> categoryViewModels = categoryAppService.GetAllCategories();
            List<ProductViewModel> productViewModels = productAppService.GetAllProducts();
            return Ok(new KeyValuePair<List<CategoryViewModel>, List<ProductViewModel>>(categoryViewModels, productViewModels));
        }

        // GET: Product
        [HttpGet]
       [Route("ShowAllProducts")]
        public List<ProductViewModel> Get()
        {
            List<ProductViewModel> productViewModels = productAppService.GetAllProducts();
            return productViewModels;
        }

        // GET: api/Product/5
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = ((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}


        [HttpPost]
       [Authorize(Roles = "Admin")]
        [Route("PostProduct")]
        public ProductViewModel Post(ProductViewModel productViewModel)
        {
            if (string.IsNullOrEmpty(productViewModel.Id.ToString()) && string.IsNullOrEmpty(productViewModel.Name))
                return new ProductViewModel
                {
                    Id = 0,
                    Name = "",
                };
            productAppService.SaveNewProduct(productViewModel);
            return productViewModel;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("CreateProduct")]
        /****The Way to Create product With IMAGE*****/
        public IHttpActionResult Create(ProductViewModel productViewModel)
        {
            var categories = categoryAppService.GetAllCategories();
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }


            var postedFiles = HttpContext.Current.Request.Files;
            if (postedFiles.Count == 0)
            {
                return BadRequest();
            }

            HttpPostedFile Image = postedFiles[0];

            if (Image != null && Image.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Resources/images"), fileName);
                Image.SaveAs(path);
                productViewModel.Image = fileName;

                productAppService.SaveNewProduct(productViewModel);
                return Ok(productViewModel);

            }
            else
                return BadRequest();
        }




        /* To Upload Photos*/
        //[Route("api/Poducts/SaveFile")]
        //public string SaveFile()
        //{
        //    try
        //    {
        //        var httpRequest = HttpContext.Current.Request;
        //        var postedFile = httpRequest.Files[0];
        //        string Image = postedFile.FileName;
        //        var physicalPath = HttpContext.Current.Server.MapPath("~/Content/Resources/images/" + Image);

        //        postedFile.SaveAs(physicalPath);

        //        return Image;
        //    }
        //    catch (Exception)
        //    {

        //        return "anonymous.jpg";
        //    }
        //}

        //[HttpGet]
        //[Route("downloadImage")]
        //public HttpResponseMessage DownloadImageFile(int id)
        //{
        //    var p = productAppService.GetProduct(id);
        //    try
        //    {
        //        //string downloadPath = HttpContext.Current.Server.MapPath("~/uploads") + "/test.jpg";
        //        var localFilePath = HttpContext.Current.Server.MapPath("~/Content/Resources/images/" + p.Image);



        //        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //        response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
        //        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");

        //        string contentDisposition = string.Concat("attachment; filename=", p.Image);
        //        response.Content.Headers.ContentDisposition =
        //                      ContentDispositionHeaderValue.Parse(contentDisposition);
        //        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        //        response.Content.Headers.ContentDisposition.FileName = p.Image;

        //        return response;
        //    }
        //    catch
        //    {
        //        HttpResponseMessage response = new HttpResponseMessage();
        //        response.StatusCode = HttpStatusCode.InternalServerError;
        //        return response;
        //    }
        //}


        //[HttpPost]
        //[Route("CreateProduct")]
        ////[Authorize]
        //public ProductViewModel Post(ProductViewModel productViewModel, HttpPostedFileBase Image)
        //{

        //    if (ModelState.IsValid == false)
        //    {
        //        return productViewModel;
        //    }
        //    if (Image != null)
        //    {
        //        if (Image.ContentLength > 0)
        //        {
        //            var httpRequest = HttpContext.Current.Request;
        //            var fileName = Path.GetFileName(Image.FileName);
        //            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Resources/images"), fileName);
        //            Image.SaveAs(path);
        //            productViewModel.Image = fileName;

        //            productAppService.SaveNewProduct(productViewModel);

        //        }
        //    }

        //    return productViewModel;
        //}


        [HttpPut]
        //99898
        [Route("EditProduct")]
       // [Authorize(Roles = "Admin")]
        public ProductViewModel EditProduct(int id, ProductViewModel productViewModel)
        {


            productAppService.UpdateProduct(productViewModel);
            // return RedirectToAction("Index");
            return productAppService.GetProduct(id);

        }

        //[HttpGet]
        //[Route("EditProductGet")]
        //public ProductViewModel put(int id)
        //{
        //    return productAppService.GetProduct(id);
        //}



        [HttpDelete]
        [Route("DeleteProduct")]
        [Authorize(Roles = "Admin")]
        //[Authorize]

        public void Delete(int id)
        {
            productAppService.DeleteProduct(id);
            //return Ok(); //can not refresh
        }

     
    }

}