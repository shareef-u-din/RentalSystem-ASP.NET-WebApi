using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Interfaces
{
    public interface IProduct<T>
    {
        IEnumerable<T> GetAll(int vendorId=0);
        IEnumerable<T> GetAllByVendor(int vendorId);
        IEnumerable<T> GetAllByCategory(int categoryId);
        IEnumerable<T> GetAllAvailable(int vendorId=0);
        IEnumerable<T> GetAllByInRange(int startPrice,int endPrice);
        T Insert(T entity);
    }
}
