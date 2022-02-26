using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public List<Article>? Articles { get; set; }
    }
}