using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmailApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {


        private readonly IEmailSender _emailSender;

        private readonly ILogger<SendEmailController> _logger;

        public SendEmailController(ILogger<SendEmailController> logger , IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        
        
        // send mail without attachment
        [HttpGet]
        public async Task<string> Get()
        {
            var rng = new Random();
            
            
            // var message = new Message(new string[] { "masoud.shayannejad@gmail.com" }, "Test email", "This is the content from our email.");
            // _emailSender.SendEmail(message);       
            
            
            var message = new Message(new string[] { "user2@gmail.com" }, "Test email async", "This is the content from our async email.",null);
            await _emailSender.SendEmailAsync(message);        
            
            

            return "the Email without attachment has been sent to the user but asynchronously";
        }
        
        
        
        // send mail with attachment
        [HttpPost]
        public async Task<string> Post()
        {
            var rng = new Random();
            
            
            // var message = new Message(new string[] { "masoud.shayannejad@gmail.com" }, "Test email", "This is the content from our email.");
            // _emailSender.SendEmail(message);       
            
            
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
 
            var message = new Message(new string[] { "user2@gmail.com" }, "Test mail with Attachments with async", "This is the content from our async mail with attachments.", files);
            await _emailSender.SendEmailAsync(message);   
            
            return "the Email with attachment has been sent to the user but asynchronously";

        }
    }
}