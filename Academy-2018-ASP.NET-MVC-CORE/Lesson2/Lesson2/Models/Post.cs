using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Models
{
    public class Post
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserId { get; set; }

        public int Likes { get; set; }

        public List<Comment> Comments { get; set; }

        public int CommentsCount { get; set; }
    }
}
