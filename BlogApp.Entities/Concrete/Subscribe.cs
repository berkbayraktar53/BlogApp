using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Subscribe : IEntity
    {
        [Key]
        public int SubscribeId { get; set; }
        public string? Mail { get; set; }
        public bool Status { get; set; }
    }
}