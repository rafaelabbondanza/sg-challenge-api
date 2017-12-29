using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGChallenge.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public int ArticleTrackerId { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
    }
}