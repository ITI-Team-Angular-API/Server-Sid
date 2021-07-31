using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BL.AppServices;
using BL.ViewModel;

namespace WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("api/Category")]

    public class CategoryController : ApiController
    {

        CategoryAppService categoryAppService = new CategoryAppService();
        // GET: Category
        [HttpGet]
        [Route("ShowAllCategories")]
        public List<CategoryViewModel> Index()
        {
            List<CategoryViewModel> categoryViewModels = categoryAppService.GetAllCategories();
            return categoryViewModels;
        }

        /*  public IHttpActionResult GetProduct(int id)
          {
              var product = categoryAppService.FirstOrDefault((p) => p.Id == id);
              if (product == null)
              {
                  return NotFound();
              }
              return Ok(product);
          } */
        [HttpPost]
        [Route("DeleteCategory")]
        //[Authorize]

        public void Delete(int id)
        {
            categoryAppService.DeleteCategory(id);
            //return Ok(); //can not refresh
        }
        [HttpPost]
        [Route("CreateCategory")]
        //[Authorize]
        public CategoryViewModel Create(CategoryViewModel categoryViewModel)
        {
            //if (ModelState.IsValid == false)
            //    return View(categoryViewModel);
            if (string.IsNullOrEmpty(categoryViewModel.Id.ToString()) && string.IsNullOrEmpty(categoryViewModel.Name))
                return new CategoryViewModel
                {
                    Id = 0,
                    Name=""
                };
                categoryAppService.SaveNewCategory(categoryViewModel);
            return categoryViewModel;
           // return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("EditCategoryGet")]
        public CategoryViewModel Edit(int id)
        {
            return categoryAppService.GetCategory(id);
        }

        [HttpPost]
        //99898
        [Route("EditCategory")]
        public CategoryViewModel Edit(int id, CategoryViewModel categoryViewModel)
        {
           

            categoryAppService.UpdateCategory(categoryViewModel);
            // return RedirectToAction("Index");
            return categoryAppService.GetCategory(id);
            
        }


    }     
}