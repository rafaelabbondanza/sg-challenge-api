using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGChallenge.Models
{
    public class ArticleTracker
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Pixel")]
        public string PixelCode { get; set; }        
        public Pixel Pixel { get; set; }
    }
}