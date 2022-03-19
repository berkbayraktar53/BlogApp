using BlogApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entities.Concrete
{
    public class ArticleRating : IEntity
    {
        [Key]
        public int ArticleRatingId { get; set; }
        public int ArticleId { get; set; }
        public int TotalScore { get; set; }
        public int TotalCount { get; set; }
    }
}