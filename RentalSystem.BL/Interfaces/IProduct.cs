using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Interfaces
{
    public interface IProduct<T>
    {
        /// <summary>
        /// Used to get all the products of given vendor id or the products of all vendors if Id is not passed
        /// </summary>
        /// <param name="vendorId">The optional int parameter for vendorid</param>
        IEnumerable<T> GetAll(int vendorId=0);

        /// <summary>
        /// Used to get all available products
        /// </summary>
        IEnumerable<T> GetAvailable();

        /// <summary>
        /// Used to get all the products of given vendor id
        /// </summary>
        /// <param name="vendorId">The int parameter for vendorid</param>
        IEnumerable<T> GetAllByVendor(int vendorId);

        /// <summary>
        /// Used to get all the products of given categoryId
        /// </summary>
        /// <param name="categoryId">The int parameter for categoryId</param>
        IEnumerable<T> GetAllByCategory(int categoryId);

        /// <summary>
        /// Used to get all the available products of given vendorId
        /// </summary>
        /// <param name="vendorId">The int parameter for vendorId</param>
        IEnumerable<T> GetAllAvailable(int vendorId=0);

        /// <summary>
        /// Used to get all the available products with unitprice between startPrice and endPrice
        /// </summary>
        /// <param name="startPrice">The int parameter for startPrice</param>
        /// <param name="endPrice">The int parameter for endPrice</param>
        IEnumerable<T> GetAllByInRange(int startPrice,int endPrice);

        /// <summary>
        /// Used to get all the available Categories
        /// </summary>
        IEnumerable<CategoryModel> GetCategories();

        /// <summary>
        /// Used to get the product by product Id
        /// </summary>
        /// <param name="ProductId">The int parameter for ProductId</param>
        T GetById(int id);

        /// <summary>
        /// Used to insert product into database
        /// </summary>
        /// <param name="object">The ProductModel object as parameter</param>
        T Insert(T entity);

        /// <summary>
        /// Used to update product
        /// </summary>
        /// <param name="productModel">The ProductModel object as parameter</param>
        T Update(T productModel);
    }
}
