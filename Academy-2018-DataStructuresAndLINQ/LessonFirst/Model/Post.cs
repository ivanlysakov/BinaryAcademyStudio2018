using LessonFirst.Model;
using System;
using System.Collections.Generic;


namespace LessonFirst
{
    class Post 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments {get; set;}
        public int CommentsCount { get; set;}


        public override string ToString()
        {
            return $"Post with id {Id} has {Likes} likes and {CommentsCount} comments";
        }
    }
}
