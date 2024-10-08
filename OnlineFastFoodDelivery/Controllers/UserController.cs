﻿using BLL.Implementation;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Http;
using BLL.Interfaces;
using OnlineFastFoodDelivery.Utilites;
using System.Reflection;

namespace OnlineFastFoodDelivery.Controllers
{
    public class UserController : Controller
    {
        bool IsSuccess = false;
        //public IFormFile imageFile { get; set; }//this is necessary to accept a file or get a file through httpcontext
        public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        UserLogin DAL= new UserLoginDao();
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(string Username, string Password)
        {
            User user = new User();
            if (Password != null)
            {
                string hashString =await DAL.GetHashString(Username);
                if (hashString != null)
                {
                    bool isValid = _passSecurity.verify(Password, hashString);
                    if (isValid)
                    {
                        user = await DAL.Login(Username, hashString);
                        if (user != null)
                        {
                            HttpContext.Session.SetString("UserName", user.FullName);
                            HttpContext.Session.SetInt32("UserID", (int)user.UserId);
                            if (user.UserId != null)
                            {
                                CartDAO cartDAL = new CartDao();
                                int CartNumber = await cartDAL.GetTotalNumberOFItemsInCart((int)user.UserId);
                                if (CartNumber != 0)
                                {
                                    HttpContext.Session.SetInt32("CartNumber", (int)CartNumber);
                                }

                            }
                        }
                        TempData["Success"] = "Welcome " + user.FullName;
                        return RedirectToAction("UserProfile", "Home", new { Id = user.UserId });
                    }
                    else
                    {
                        TempData["Error"] = "Login Failed!";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "ID does not exist!";
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "Login Failed!";
                return View();
            }

        }
        public IActionResult UserSignUp()
        {
            return View();  
        }
        public async Task<bool> Checkusername(string Username)
        {
            try
            {
                IsSuccess = await DAL.checkUsername(Username);
                
                return IsSuccess;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UserSignUp(User user)
       {
            try
            {
                if (HttpContext.Request.Form.Files.Count > 0) 
                {
                    user.imageFile = HttpContext.Request.Form.Files[0];
                    if (user.imageFile != null)
                    {
                        var extension = Path.GetExtension(user.imageFile.FileName);
                        if (ImageExtensions.Contains(extension.ToUpperInvariant()))
                        {
                            NecessaryFunctions nec = new NecessaryFunctions();
                            user.Image = nec.ImageSave(user.Image, user.imageFile);
                        }
                    }
                    
                }

                if (user != null)
                {
                    if (user.Password != null)
                    {
                        byte[] salt;
                        string _hashPassword = _passSecurity.Hashpassword(user.Password, out salt);
                        if (_hashPassword != null)
                        {
                            user.Password = _hashPassword;
                            user.Salt = salt;
                        }

                    }
                    bool isSuccess = false;
                    isSuccess = await DAL.SignUp(user);
                    if (isSuccess)
                    {
                        TempData["Success"] = "Registered Successfully ! Please Login";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Registration Failed";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Registration Failed";
                    return View();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        [HttpPost]
        public async Task<User> FindUserByUsername([FromBody] string UserName)
        {
            User user=await DAL.GetUserByUsername(UserName);
            if (user != null)
            {
                HttpContext.Session.SetInt32("Temp_UserID", Convert.ToInt32(user.UserId));
                return user;
            }
            else
            {
                return user;
            }
        }
        [HttpPost]
        public async Task<bool> VerifyOTP([FromBody] string OTP)
        {
            try
            {
                var currentTime= DateTime.Now;
                var creationTime = DateTime.Parse(HttpContext.Session.GetString("OTPCreationTimeStamp"));
                if ((currentTime-creationTime).TotalSeconds<30)
                {
                    if (OTP == (string)HttpContext.Session.GetString("OTP"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    HttpContext.Session.Remove("OTPCreationTimeStamp");
                    //HttpContext.Session.Remove("")
                    return false;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<bool> ResetPassword([FromBody] string Password)
        {
            
            int UserID = Convert.ToInt32(HttpContext.Session.GetInt32("Temp_UserID"));
            User user = new User();
            if (Password != null)
            {
                
                byte[] salt;
                string _hashPassword = _passSecurity.Hashpassword(Password, out salt);
                if (_hashPassword != null)
                {
                   user.Password = _hashPassword;
                   user.Salt = salt;
                }
                IsSuccess = await DAL.UpdatePassword(UserID, user);
                
            }
            if (IsSuccess)
            {
                HttpContext.Session.Remove("Temp_UserID");
                return true;
            }
            else
            {
                return false;
            }

        }
       
        
       
    }
}
//twilio Recovery code -449YG2LBA4HH9AXM11LGRKKD