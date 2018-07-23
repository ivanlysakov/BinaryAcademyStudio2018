using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Models.QueriesModels
{
    public class PostQuery
    {
        public Post Post { get; set; }
        public Comment LargestComment { get; set; }
        public Comment PopularComment { get; set; }
        public int CommentsForPost { get; set; }
    }
}
