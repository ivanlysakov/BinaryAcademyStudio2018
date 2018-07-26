using Lesson2.Models;
using Lesson2.Models.QueriesModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson2.Services
{
    public class DataService
    {
        static List<User> users;

        public DataService() 
            { 
            users = GetData();
            }
        
        public static List<T> GetDataFromSource<T>(string sufix)
        {
            using (var client = new HttpClient())
            {
                string url = "https://5b128555d50a5c0014ef1204.mockapi.io";
                var content = client.GetStringAsync($"{url}/{sufix}").Result;
                return JsonConvert.DeserializeObject<List<T>>(content);
            }

        }

        public List<User> GetData()
        {
            var users = GetDataFromSource<User>("users");
            var posts = GetDataFromSource<Post>("posts");
            var comments = GetDataFromSource<Comment>("comments");
            var todos = GetDataFromSource<Todo>("todos");

            var posts_new = from post in posts
                            select new Post
                            {
                                Id = post.Id,
                                CreatedAt = post.CreatedAt,
                                Title = post.Title,
                                Body = post.Body,
                                UserId = post.UserId,
                                Likes = post.Likes,
                                Comments = comments.Where(x => x.PostId == post.Id).ToList()
                            };

            var users_new = from user in users
                            select new User
                            {
                                Id = user.Id,
                                Name = user.Name,
                                Avatar = user.Avatar,
                                Email = user.Email,
                                Posts = posts_new.Where(x => x.UserId == user.Id).ToList(),
                                Todos = todos.Where(x => x.UserId == user.Id).ToList(),
                                Comments = comments.Where(x => x.UserId == user.Id).ToList()
                            };

            return users_new.ToList();
        }

        public static User GetUserById(int userid)
        {
            return users.Where(x => x.Id == userid).FirstOrDefault();
        }

        public static Post GetPostById(int postid)
        {
            return users.SelectMany(x=> x.Posts).Where(x => x.Id == postid).FirstOrDefault();
        }
        
        public static Todo GetTodoById(int todoid)
        {
            return users.SelectMany(x => x.Todos).Where(x => x.Id == todoid).FirstOrDefault();
        }

        public static List<User> GetAllUsers() 
        { 
            return users;
        }
        
        public static List<User> GetSortedUsers()
        {
            return users.OrderBy(x => x.Name).ThenBy(x => x.Todos.OrderByDescending(y => y.Name.Length)).ToList();
        }
        
        public static List<Post> GetCommentsForPost(int userid)
        {
            var posts = from user in users
                        from post in user.Posts
                        where user.Id == userid
                        select new Post
                        {
                            Id = post.Id,
                            Title = post.Title,
                            Body = post.Body,
                            CommentsCount = post.Comments.Count()
                        };

           return posts.ToList();


        }

        public static List<Comment> GetSmallComments(int userid)
        {
            var comments = from user in users
                           from comment in user.Comments
                           where user.Id == userid && comment.Body.Length < 50
                           select new Comment
                           {
                               Id = comment.Id,
                               
                               Body = comment.Body,
                               Likes = comment.Likes
                           };

            return comments.ToList();
        }

        public static List<Todo> GetTodosCompleted(int userid)
        {
            var todos = from user in users
                        from todo in user.Todos
                        where user.Id == userid && todo.IsComplete == true
                        select new Todo
                        {
                            Id = todo.Id,
                            Name = todo.Name
                        };

           return todos.ToList();
        }

        public static UserQuery GetUserNewStruct (int userid)
        {
            var result = from user in users
                         let post = user.Posts.OrderByDescending(y => y.CreatedAt).FirstOrDefault()
                         where user.Id == userid
                         select new UserQuery
                         {
                             User = user,
                             LatestPost =post,
                             CommentsForLatestPost = post?.Comments.Count,
                             InComlpetedTodos = user.Todos.Where(x => x.IsComplete == false)?.Count(),
                             PopularPostbyComments = user.Posts.OrderByDescending(p => p.Comments.Count()).FirstOrDefault(),
                             PopularPostbyLikes = user.Posts.OrderByDescending(x => x.Likes).FirstOrDefault()
                         };
            return result.FirstOrDefault();
        }

        public static PostQuery GetPostNewStruct(int postid)
        {

            var result = from user in users
                         from post in user.Posts
                         where post.Id == postid
                         select new PostQuery
                         {
                             Post = post,
                             LargestComment = post.Comments.OrderByDescending(x => x.Body.Length).FirstOrDefault(),
                             PopularComment = post.Comments.OrderByDescending(x => x.Likes).FirstOrDefault(),
                             CommentsForPost = post.Comments.Where(x => x.Body.Length < 80 && x.Likes == 0).Count()
                         };

           return result.FirstOrDefault();

        }

    }
}
