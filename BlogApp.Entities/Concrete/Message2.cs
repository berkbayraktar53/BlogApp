using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Message2 : IEntity
    {
        [Key]
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string? Subject { get; set; }
        public string? Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public Writer? SenderUser { get; set; }
        public Writer? ReceiverUser { get; set; }
    }
}