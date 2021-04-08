using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Model
{
    public class Emploee
    {
        public long EmploeeID { get; set; }
        public string EmploeeName { get; set; } = "Yahyo";
        public string Department { get; set; } = "IT English";
        public string MailId { get; set; } = "Yahyo@gmail.com";
        public DateTime DOJ { get; set; } = DateTime.Parse("2021/03/03");
    }
}
