using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Notification : IEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public string? Type { get; set; }
        public string? TypeSymbol { get; set; }
        public string? Color { get; set; }
        public string? Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}