using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonFirst.Core
{
    class Service
    {
        
        public DataSource Source {get;set;}
        
        public Service() 
        {
            Source = new DataSource();
           
        }
   
        public void GetSortedUsers(List<User> users)
        {
            var result = users.OrderBy(x => x.Name).ThenBy(x => x.Todos.OrderByDescending(y => y.Name.Length));

            foreach (var user in result)
            {
                Console.WriteLine( user );
                foreach (var todo in user.Todos)
                {
                    Console.WriteLine($"---------{todo}");
                }
            }
        }

        public void GetCommentsForPost(List<User> users, int userid)
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

            Console.WriteLine($"User with id {userid} has {posts.Count()} posts");
            
                       
                foreach (var post in posts)
                {
                Console.WriteLine($"{post.Id} --- {post.Title} : {post.Body} --- {post.CommentsCount} comments");
                } 
            
                
        }

        public void GetSmallComments(List<User> users, int userid)
        {
            var comments = from user in users
                           from comment in user.Comments
                           where user.Id == userid
                           where comment.Body.Length < 50
                           select new Comment
                           {
                               Id = comment.Id,
                               Body = comment.Body,
                               Likes = comment.Likes
                           };

            Console.WriteLine($"User with id {userid} has {comments.Count()} small comments for his posts");
            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
        }

        public  void GetTodosCompleted(List<User> users, int userid)
        {
            var todos = from user in users
                        from todo in user.Todos
                        where user.Id == userid
                        where todo.IsComplete == true
                        select new Todo
                        {
                            Id = todo.Id,
                            Name = todo.Name
                        };

            Console.WriteLine($"User with id {userid} has {todos.Count()} completed tasks");
            foreach (var todo in todos)
            {
                Console.WriteLine(todo);
            }
        }

        public  void GetUserNewStruct(List<User> users, int userid)
        {

            var _users = from user in users
                         let LatestPost = user.Posts.OrderByDescending(y => y.CreatedAt).FirstOrDefault()
                         where user.Id == userid
                         select new
                         {
                             user.Name,
                             LatestPost,
                             CommentsForLatestPost = LatestPost?.Comments.Count,
                             InComlpetedTodos = user.Todos.Where(x => x.IsComplete == false)?.Count(),
                             PopularPostbyComments = user.Posts.Where(x => x.Body.Length < 80).OrderByDescending(x => x.CommentsCount).FirstOrDefault(),
                             PopularPostbyLikes = user.Posts.OrderByDescending(x => x.Likes).FirstOrDefault()
                         };


            foreach (var item in _users)
            {
                Console.WriteLine("********************************************");
                Console.WriteLine($"User {item.Name}");
                Console.WriteLine($"Last post:  {item.LatestPost?.Body}");
                Console.WriteLine($"Comments for last post: {item.CommentsForLatestPost}");
                Console.WriteLine($"IncompletedTodos: {item.InComlpetedTodos}");
                Console.WriteLine($"Most popular post by comments: {item.PopularPostbyComments}");
                Console.WriteLine($"Most popular post by likes: {item.PopularPostbyLikes?.Body}");
            }



        }

        public  void GetPostNewStruct(List<User> users, int postid)
        {

            var _posts = from user in users
                         from post in user.Posts
                         where post.Id == postid
                         select new
                         {
                             post.Title,
                             LargestComment = post.Comments.OrderByDescending(x => x.Body.Length).FirstOrDefault(),
                             PopularComment = post.Comments.OrderByDescending(x => x.Likes).FirstOrDefault(),
                             CommentsForPost = post.Comments.Where(x => x.Body.Length < 80 && x.Likes == 0)?.Count()
                         };


            foreach (var item in _posts)
            {
                Console.WriteLine("********************************************");
                Console.WriteLine($"Post {item.Title}");
                Console.WriteLine($"LargestComment:  {item.LargestComment?.Body}");
                Console.WriteLine($"PopularComment: {item.PopularComment?.Body}");
                Console.WriteLine($"CommentsForPost: {item.CommentsForPost}");

            }



        }
    }
}
