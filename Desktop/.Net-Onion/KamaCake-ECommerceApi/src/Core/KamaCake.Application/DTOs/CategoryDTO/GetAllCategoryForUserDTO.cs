using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaCake.Application.DTOs.CategoryDTO
{
    public class GetAllCategoryForUserDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } 
        public string CategoryDescription { get; set; }
    }
}
