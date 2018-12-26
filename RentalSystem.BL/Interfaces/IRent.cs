using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Used to set the product on rent for customer
        /// </summary>
        /// <param name="entity">The RentProducts class object</param>
        T Insert(T entity);

        /// <summary>
        /// Used to check the start  and end date for productId.
        /// </summary>
        /// <param name="productId">The product Id</param>
        int CheckDate(DateTime date, int productId,int value);
    }
}
