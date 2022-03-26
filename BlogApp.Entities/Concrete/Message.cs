using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int MessageId { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? Subject { get; set; }
        public string? Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}