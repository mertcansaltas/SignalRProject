using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            AppUser appUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email=registerDto.Mail,
                UserName=registerDto.Username
            };
            var result= await userManager.CreateAsync(appUser, registerDto.Password); 
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();  
        }
    }
}
