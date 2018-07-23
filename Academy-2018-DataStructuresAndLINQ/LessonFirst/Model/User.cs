using System;
using System.Collections.Generic;

namespace LessonFirst
{
    class User 
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public List<Post> Posts {get; set;}
        public List<Todo> Todos { get; set;}
        public List<Comment> Comments { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }


   


}
