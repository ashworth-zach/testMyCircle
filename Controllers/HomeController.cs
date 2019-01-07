using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myCircle.Models;

namespace myCircle.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
 
        public HomeController(Context context){
            dbContext = context;
        }
        //=========================================================
        [HttpPost("/registeration")]
        public JsonResult registeration([FromBody] users newUser)
        {
            if(ModelState.IsValid){
                if(dbContext.users.Any(u => u.email == newUser.email)){
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("email", "Email is already in use");
                    return Json(error);
                }

                PasswordHasher<users> Hasher = new PasswordHasher<users>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);

                dbContext.users.Add(newUser);
                dbContext.SaveChanges();
                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else{
                return Json(ModelState);
            }
        }
        [HttpPost("loggingIn")]
        public IActionResult loginUser(Login exUser){
            if(ModelState.IsValid){
                var userInDb = dbContext.users.FirstOrDefault(u => u.email == exUser.email);
                Dictionary<string, string> error = new Dictionary<string, string>();
                if(userInDb == null){
                    error.Add("Message", "Error");
                    error.Add("email", "Invalid email");
                    return Json(error);
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(exUser, userInDb.password, exUser.password);

                if(result == 0){
                    error.Add("Message", "Error");
                    error.Add("password", "Invalid password");
                    return Json(error);
                }

                HttpContext.Session.SetInt32("UserId", userInDb.userId);
                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else{
                return Json(ModelState);
            }
        }
        //=========================================================
        [HttpGet("/editor/{id}")]
        public IActionResult userEditting(int id){
            if(dbContext.users.Any(usr => usr.userId == id)){
                users editThis = dbContext.users.FirstOrDefault(usr => usr.userId == id);
                return Json(editThis);
            }
            else{
                Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("user", "Invalid User ID");
                    return Json(error);
            }
        }

        [HttpPost("/update")]
        public IActionResult editUser([FromBody] users updateUser){
            users RetrievedUser = dbContext.users.FirstOrDefault(users => users.userId == updateUser.userId);
            //===================================================================================================
            List<users> oneUser = dbContext.users.Where(usr => usr.userId == updateUser.userId).ToList();
            List<users> butOne = dbContext.users.Except(oneUser).ToList();
            //===================================================================================================
            if(ModelState.IsValid){
                if(butOne.Any(u => u.email == updateUser.email)){
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("email", "Email is already in use");
                    return Json(error);
                }
                else{
                    RetrievedUser.username = updateUser.username;
                    RetrievedUser.email = updateUser.email;
                    RetrievedUser.password = updateUser.password;
                    dbContext.SaveChanges();
                    Dictionary<string, string> success = new Dictionary<string, string>();
                    success.Add("Message", "Success");
                    return Json(success);
                }
            }
            else{
                return Json(ModelState);
            }  
        }
        [HttpGet("delete/{id}")]
        public IActionResult deletor(int id){
            users ReturnedValues = dbContext.users.FirstOrDefault(users => users.userId == id);
            dbContext.users.Remove(ReturnedValues);
            dbContext.SaveChanges();
            
            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("Message", "Success");
            return Json(success);
        }
        //===========================================================================
        [HttpPost("/createImage")]
        public IActionResult creation(images newImage)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("here");
            Console.WriteLine("========================================");
            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("Message", "Success");
            return Json(success);
        }
    }

}
