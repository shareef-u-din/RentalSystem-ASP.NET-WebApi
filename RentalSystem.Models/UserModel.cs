using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        public Nullable<int> PaymentId { get; set; }
        public Nullable<bool> Valid { get; set; }
        public string Photo { get; set; }
    }
}
