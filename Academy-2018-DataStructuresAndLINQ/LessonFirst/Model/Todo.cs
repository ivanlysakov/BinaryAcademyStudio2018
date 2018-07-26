using LessonFirst.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonFirst
{
    class Todo 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Todo with id {Id} --- {Name} ";
        }

    }
}
