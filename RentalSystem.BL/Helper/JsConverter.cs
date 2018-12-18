using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RentalSystem.BL.Helper
{
    public static class JsConverter
    {
        public static string TableToJson(DataTable table)
        {
            string JSONString = string.Empty;

            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
