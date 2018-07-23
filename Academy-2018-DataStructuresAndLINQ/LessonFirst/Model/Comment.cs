using LessonFirst.Model;
using System;

namespace LessonFirst
{
    class Comment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }


        public override string ToString()
        {
            return $"Comment with id {Id} --- {Body} ";
        }
    }
}
