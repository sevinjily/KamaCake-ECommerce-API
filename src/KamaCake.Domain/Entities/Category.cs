using KamaCake.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Domain.Entities
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }


    }
}
