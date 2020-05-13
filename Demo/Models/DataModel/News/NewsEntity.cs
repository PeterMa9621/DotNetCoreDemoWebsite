using Demo.Models.DataModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.DataModel.News
{
    public class NewsEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public long CreatedAt { get; set; }
        public Nullable<long> UpdatedAt { get; set; }
        public string Category { get; set; }
    }
}
