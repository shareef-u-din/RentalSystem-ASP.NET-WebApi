using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.Models;

namespace RentalSystem.BL.Interfaces
{
    public interface IRent<T>
    {
        /// <summary>
        /// Used to get all the products of vendor currently on rent
        /// </summary>
        /// <param name="vendorId">The Id of the vendor</param>
        IEnumerable<T> GetAllOnRent(int vendorId);
        /// <summary>
        /// Used to get all the products  currently on rent for customer
        /// </summary>
        /// <param name="email">The Id of the vendor</param>
        IEnumerable<T> GetAllOnRent(string email);

        /// <summary>
        /// Used to set the product on rent for customer
        /// </summary>
        /// <param name="entity">The RentProducts class object</param>
        T Insert(T entity);

        /// <summary>
        /// Used to check the start  and end date for productId.
        /// </summary>
        /// <param name="productId">The product Id</param>
        int CheckDate(DateTime date, int productId,int value);

        /// <summary>
        /// Used to get all the new rent requests for given vendor
        /// </summary>
        /// <param name="productId">The Vendor Id, if not provided returns all Unapproved requests.</param>
        IEnumerable<T> GetAllOnRentUnApproved(int vendorId);

        /// <summary>
        /// Used to approve the product on rent.
        /// </summary>
        /// <param name="productId">The product rent Id</param>
        int Approve(int productId);

        /// <summary>
        /// Used to unapproved the products for customer.
        /// </summary>
        /// <param name="email">The unique email of customer</param>
        IEnumerable<T> GetAllUnApproved(string email);
    }
}
