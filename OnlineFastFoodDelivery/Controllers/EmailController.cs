using BLL.Implementation;
using BLL.Interfaces;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Models;
using static System.Net.WebRequestMethods;

namespace OnlineFastFoodDelivery.Controllers
{
    public class EmailController : Controller
    {
        private readonly SendMailDAO mailService;
        public EmailController(SendMailDAO mailService) 
        {
            this.mailService=mailService;
        }
        [HttpPost]
        public async Task<bool> SendOTP([FromBody] string EMailID)
        {
            bool isSuccess = false;
            try
            {
               UserLogin DAL=new UserLoginDao();
                string OTP = await DAL.GenerateOTP();
                if (OTP != null)
                {
                    Email emailMessage = new Email
                    {
                        ToEmail = EMailID,
                        Subject = string.Format("OTP To Reset Password"),
                        Body = string.Format("Hey User !,<br/><br/> The OTP to reset your password is <b>{0}</b>.<br/><br/> Please use it to reset your password", OTP)
                    };
                   
                    isSuccess=await mailService.SendMailAsync(emailMessage);
                    var creationTime=DateTime.Now;
                    HttpContext.Session.SetString("OTP", OTP);
                    HttpContext.Session.SetString("OTPCreationTimeStamp", creationTime.ToString());
                }
                if (isSuccess)
                {
                   
                    return true;
                    
                }
                else
                {
                    
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                
                TempData["Error"] = "Authentication Failed";
                return false;
            }
        }
        public async Task<bool> SendEmail([FromBody] string EMailID)
        {
            bool isSuccess = false;
            try
            {
                UserLogin DAL = new UserLoginDao();
                string OTP = await DAL.GenerateOTP();
                if (OTP != null)
                {
                    Email emailMessage = new Email
                    {
                        ToEmail = EMailID,
                        Subject = string.Format("OTP To Reset Password"),
                        Body = string.Format("Hey User !,<br/><br/> The OTP to reset your password is <b>{0}</b>.<br/><br/> Please use it to reset your password", OTP)
                    };

                    isSuccess = await mailService.SendMailAsync(emailMessage);
                    var creationTime = DateTime.Now;
                    HttpContext.Session.SetString("OTP", OTP);
                    HttpContext.Session.SetString("OTPCreationTimeStamp", creationTime.ToString());
                }
                if (isSuccess)
                {

                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                TempData["Error"] = "Authentication Failed";
                return false;
            }
        }
        
    }
}
