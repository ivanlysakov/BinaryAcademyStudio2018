using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Models.Helpers
{
    public class UserComments
    {
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
