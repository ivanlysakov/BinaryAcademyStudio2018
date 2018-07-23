using Lesson2.Models.Helpers;
using Lesson2.Services;
using Microsoft.AspNetCore.Mvc;


namespace Lesson2.Controllers
{
    public class UsersController : Controller
    {
        //GET:/Users/ShowAllUsers
        public IActionResult ShowAllUsers()
        {
            return View(DataService.GetAllUsers());
        }

        //GET:/Users/GetSortedUsers
        public IActionResult GetSortedUsers()
        {
            return View(DataService.GetSortedUsers());
        }
        
        //GET:/Users/UserById/id
        public IActionResult UserById(int id)
        {
            return View(DataService.GetUserById(id));
        }

        //GET:/Users/PostById/id
        public IActionResult PostById(int id)
        {
            return View(DataService.GetPostById(id));
        }

        //GET:/Users/TodoById/id
        public IActionResult TodoById(int id)
        {
            return View(DataService.GetTodoById(id));
        }

        //GET:/Users/GetCommentsForPost
        [HttpGet]
        public IActionResult GetCommentsForPost()
        {
            return View();
        }

        [HttpPost]
        //POST:/Users/GetCommentsForPost
        public IActionResult GetCommentsForPost(UserPosts mymodel)
        {

            if (!ModelState.IsValid)
            {
                return View(mymodel);
            }
            mymodel.Posts = DataService.GetCommentsForPost(mymodel.User.Id);
            mymodel.User = DataService.GetUserById(mymodel.User.Id);
            return View(mymodel);
        }

        //GET:/Users/GetSmallComments
        [HttpGet]
        public IActionResult GetSmallComments()
        {
            return View();
        }

        [HttpPost]
        //POST:/Users/GetSmallComments
        public IActionResult GetSmallComments(UserComments mymodel)
        {
            if (!ModelState.IsValid)
            {
                return View(mymodel);
            }
            mymodel.Comments = DataService.GetSmallComments(mymodel.User.Id);
            mymodel.User = DataService.GetUserById(mymodel.User.Id);
            return View(mymodel);
        }

        //GET:/Users/GetTodosCompleted
        [HttpGet]
        public IActionResult GetTodosCompleted()
        {
            return View();
        }

        [HttpPost]
        //POST:/Users/GetTodosCompleted
        public IActionResult GetTodosCompleted(UserTodos mymodel)
        {
            if (!ModelState.IsValid)
            {
                return View(mymodel);
            }
            mymodel.Todos = DataService.GetTodosCompleted(mymodel.User.Id);
            mymodel.User = DataService.GetUserById(mymodel.User.Id);
            return View(mymodel);
        }

        //GET:/Users/GetUserNewStruct
        [HttpGet]
        public IActionResult GetUserNewStruct()
        {
            return View();
        }

        [HttpPost]
        //POST:/Users/GetUserNewStruct
        public IActionResult GetUserNewStruct(UserQueryHelper mymodel)
        {
            if (!ModelState.IsValid)
            {
                return View(mymodel);
            }
            mymodel.UserQuery = DataService.GetUserNewStruct(mymodel.User.Id);
            mymodel.User = DataService.GetUserById(mymodel.User.Id);
            return View(mymodel);
        }

        //GET:/Users/GetPostNewStruct
        [HttpGet]
        public IActionResult GetPostNewStruct()
        {
            return View();
        }

        [HttpPost]
        //POST:/Users/GetPostNewStruct
        public IActionResult GetPostNewStruct(PostQueryHelper mymodel)
        {
            if (!ModelState.IsValid)
            {
                return View(mymodel);
            }
            mymodel.PostQuery = DataService.GetPostNewStruct(mymodel.Post.Id);
            mymodel.Post = DataService.GetPostById(mymodel.Post.Id);
            return View(mymodel);
        }
    }
}