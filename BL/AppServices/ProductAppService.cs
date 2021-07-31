using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Bases;
using BL.ViewModel;

namespace BL.AppServices
{
    public class ProductAppService : AppServiceBase
    {
        #region CURD

        public List<ProductViewModel> GetAllProducts()
        {

            return Mapper.Map<List<ProductViewModel>>(TheUnitOfWork.Product.GetAllProduct());
        }
        public ProductViewModel GetProduct(int id)
        {
            return Mapper.Map<ProductViewModel>(TheUnitOfWork.Product.GetProductById(id));
        }



        public bool SaveNewProduct(ProductViewModel ProductViewModel)
        {
            bool result = false;
            var Product = Mapper.Map<Product>(ProductViewModel);
            if (TheUnitOfWork.Product.Insert(Product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateProduct(ProductViewModel ProductViewModel)
        {
            var Product = Mapper.Map<Product>(ProductViewModel);
            TheUnitOfWork.Product.Update(Product);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteProduct(int id)
        {
            bool result = false;

            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(ProductViewModel ProductViewModel)
        {
            Product Product = Mapper.Map<Product>(ProductViewModel);
            return TheUnitOfWork.Product.CheckProductExists(Product);
        }

        public List<ProductViewModel> Search(string ProductName)
        {
            IQueryable<Product> products = TheUnitOfWork.Product.GetAll().Where(p => p.Name.Contains(ProductName));

            return Mapper.Map<List<ProductViewModel>>(products);
        }
        #endregion

    }
}
