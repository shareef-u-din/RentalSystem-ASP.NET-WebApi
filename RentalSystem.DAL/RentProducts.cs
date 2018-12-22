using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.DAL
{
    public class RentProducts
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
        public double UnitCost { get; set; }
        public bool Payment { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
