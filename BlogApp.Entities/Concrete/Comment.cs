using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int CommentId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
        public int BlogScore { get; set; }
        public bool Status { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}