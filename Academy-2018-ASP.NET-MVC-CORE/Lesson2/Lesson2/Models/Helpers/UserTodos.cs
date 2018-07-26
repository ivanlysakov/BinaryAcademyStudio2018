using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Models.Helpers
{
    public class UserTodos
    {
        public User User { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
