using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Entities
{
    public class ICDEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string ICDCode { get; set; }
        public string NameCode { get; set; }
    }
}
