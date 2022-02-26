using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutId { get; set; }
        public string? Detail1 { get; set; }
        public string? Detail2 { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? MapLocation { get; set; }
        public bool Status { get; set; }
    }
}