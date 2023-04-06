using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public Category Parent { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Children { get; set; }
    }
}
