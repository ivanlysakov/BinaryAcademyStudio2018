using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Models.QueriesModels
{
    public class UserQuery
    {
        public User User { get; set; }
        public Post LatestPost { get; set; }
        public int? CommentsForLatestPost { get; set; }
        public int? InComlpetedTodos { get; set; }
        public Post PopularPostbyComments { get; set; }
        public Post PopularPostbyLikes { get; set; }
    }
}
