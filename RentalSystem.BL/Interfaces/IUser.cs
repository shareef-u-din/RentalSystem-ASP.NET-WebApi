using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Interfaces
{
    public interface IUser<T>
    {
        bool Exists(string email);
        IEnumerable<T> GetAll();
        T Get(string email);
        T Insert(T entity);
        T Update(T entity);
        T ResetPassword(string oldPassword);
    }
}
