using LessonFirst.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace LessonFirst
{
    class DataSource
    {
        public List<User> GetData()
        {
            var users = GetData<User>("users");
            var posts = GetData<Post>("posts");
            var comments = GetData<Comment>("comments");
            var todos = GetData<Todo>("todos");

            var _posts = from post in posts


                         select new Post
                         {
                             Id = post.Id,
                             CreatedAt = post.CreatedAt,
                             Title=post.Title,
                             Body = post.Body,
                             UserId=post.UserId,
                             Likes=post.Likes,
                             Comments = comments.Where(x => x.PostId == post.Id).ToList()
                         }
                         ;


            var _users = from user in users
                         select new User
                         {
                             Id = user.Id,
                             Name= user.Name,
                             Posts = _posts.Where(x => x.UserId == user.Id).ToList(),
                             Todos = todos.Where(x => x.UserId == user.Id).ToList(),
                             Comments = comments.Where(x => x.UserId == user.Id).ToList()
                         };
        
           return _users.ToList();
        }
        
        public List<T> GetData<T>(string sufix)
        {
            using (var client = new HttpClient())
            {
                string url = "https://5b128555d50a5c0014ef1204.mockapi.io";
                var content = client.GetStringAsync($"{url}/{sufix}").Result;
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
         
        }
        
        
    }
}
