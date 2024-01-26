using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Setup.DAL;
using Setup.ITF.User.auth;
using Setup.Request.User.auth;
using Setup.Response.User.auth;

namespace ZordikWebApi.Controllers.User.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class ContactFormApiController : ControllerBase
    {
        private readonly IContactForm _contactForm;

        public ContactFormApiController(IContactForm contactForm)
        {
            _contactForm = contactForm;
        }

        [HttpPost]
        public CommonResponse<ContactFormResponse> SubmitContactForm([FromBody] ContactFormRequest objRequest)
        {
            return _contactForm.SubmitContactForm(objRequest);
        }
    }
}
