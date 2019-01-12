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

//==========================================================================================================
namespace myCircle.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;

        public HomeController(Context context)
        {
            dbContext = context;
        }
        //==========================================================================================================
        [HttpPost("/registeration")]
        public JsonResult registeration([FromBody] users newUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(u => u.email == newUser.email))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("email", "Email is already in use");
                    return Json(error);
                }
                if (dbContext.users.Any(u => u.username == newUser.username))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("username", "Username is already in use");
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
            else
            {
                return Json(ModelState);
            }
        }


        [HttpPost("/loggingIn")]
        public IActionResult loginUser(Login exUser)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.users.FirstOrDefault(u => u.email == exUser.email);
                Dictionary<string, string> error = new Dictionary<string, string>();
                if (userInDb == null)
                {
                    error.Add("Message", "Error");
                    error.Add("email", "Invalid email");
                    return Json(error);
                }
                var hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(exUser, userInDb.password, exUser.password);

                if (result == 0)
                {
                    error.Add("Message", "Error");
                    error.Add("password", "Invalid password");
                    return Json(error);
                }

                HttpContext.Session.SetInt32("UserId", userInDb.userId);
                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else
            {
                return Json(ModelState);
            }
        }
        //==========================================================================================================
        //USER SETTINGS AND STUFF
        //==========================================================================================================
        [HttpGet("/editor/{id}")]
        public IActionResult userEditting(int id)
        {
            if (dbContext.users.Any(usr => usr.userId == id))
            {
                users editThis = dbContext.users.FirstOrDefault(usr => usr.userId == id);
                return Json(editThis);
            }
            else
            {
                Dictionary<string, string> error = new Dictionary<string, string>();
                error.Add("Message", "Error");
                error.Add("user", "Invalid User ID");
                return Json(error);
            }
        }

        [HttpPost("/update")]
        public IActionResult editUser([FromBody] users updateUser)
        {
            users RetrievedUser = dbContext.users.FirstOrDefault(users => users.userId == updateUser.userId);
            //===================================================================================================
            List<users> oneUser = dbContext.users.Where(usr => usr.userId == updateUser.userId).ToList();
            List<users> butOne = dbContext.users.Except(oneUser).ToList();
            //===================================================================================================
            if (ModelState.IsValid)
            {
                if (butOne.Any(u => u.email == updateUser.email))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("email", "Email is already in use");
                    return Json(error);
                }
                else
                {
                    RetrievedUser.username = updateUser.username;
                    RetrievedUser.email = updateUser.email;
                    RetrievedUser.password = updateUser.password;
                    dbContext.SaveChanges();
                    Dictionary<string, string> success = new Dictionary<string, string>();
                    success.Add("Message", "Success");
                    return Json(success);
                }
            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpGet("/delete/{id}")]
        public IActionResult deletor(int id)
        {
            users ReturnedValues = dbContext.users.FirstOrDefault(users => users.userId == id);
            dbContext.users.Remove(ReturnedValues);
            dbContext.SaveChanges();

            Dictionary<string, string> success = new Dictionary<string, string>();
            success.Add("Message", "Success");
            return Json(success);
        }
        //==========================================================================================================
        //CHANNEL FUNCTIONS
        //==========================================================================================================
        [HttpGet("/getchannel/{id}")]
        public IActionResult GetChannel(int id)
        {
            channels retrievedChannel = dbContext.channels.FirstOrDefault(x => x.channelId == id);
            if (retrievedChannel.channelId == id)
            {
                return Json(retrievedChannel);
            }
            else
            {
                Dictionary<string, string> error = new Dictionary<string, string>();
                error.Add("Message", "Error");
                return Json(error);
            }
        }
        //==========================================================================================================
        //CIRCLE FUNCTIONS
        //==========================================================================================================
        [HttpGet("/getcircle/{id}")]
        public IActionResult GetCircle(int id)
        {
            circles retrievedCircle = dbContext.circles.FirstOrDefault(x => x.circleId == id);

            if (retrievedCircle.circleId == id)
            {
                return Json(retrievedCircle);//return a single circle
            }
            else
            {
                Dictionary<string, string> error = new Dictionary<string, string>();
                error.Add("Message", "Error");
                return Json(error);
            }
        }
        [HttpPost("/CreateCircle")]
        public IActionResult CreateCircle([FromBody] circles newCircle)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.circles.Any(u => u.title == newCircle.title))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("Circle", "Circle is already in use by other users");
                    return Json(error);
                }
                dbContext.circles.Add(newCircle);
                dbContext.SaveChanges();
                Dictionary<string, string> success = new Dictionary<string, string>();
                success.Add("Message", "Success");
                return Json(success);
            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpPost("/updateCircle")]
        public IActionResult editCircle([FromBody] circles Circle)
        {
            circles retrievedCircle = dbContext.circles.FirstOrDefault(circles => circles.circleId == Circle.circleId);
            if (ModelState.IsValid)
            {
                if (dbContext.circles.Any(x=>x.title==Circle.title))
                {
                    Dictionary<string, string> error = new Dictionary<string, string>();
                    error.Add("Message", "Error");
                    error.Add("circle", "Title is already in use");
                    return Json(error);
                }
                else
                {
                    retrievedCircle.title = Circle.title;
                    retrievedCircle.updatedAt = DateTime.Now;
                    dbContext.SaveChanges();
                    Dictionary<string, string> success = new Dictionary<string, string>();
                    success.Add("Message", "Success");
                    return Json(success);
                }
            }
            else
            {
                return Json(ModelState);
            }
        }
        //==========================================================================================================
        //MESSAGE FUNCTIONS
        //==========================================================================================================
        [HttpPost("/leaveMessage")]
        public IActionResult leaveMessage([FromBody] messages Message)
        {

            //chack for images somehow
            //if image save them in the images table
            //validate and save the message
            if(ModelState.IsValid)
            {
                dbContext.messages.Add(Message);
                dbContext.SaveChanges();
            }
            else{
                return Json(ModelState);
            }
        }
        //==========================================================================================================

    }

}
