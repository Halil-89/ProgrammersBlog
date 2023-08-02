using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManeger;

        public AdminMenuViewComponent(UserManager<User> userManeger)
        {
            _userManeger = userManeger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManeger.GetUserAsync(HttpContext.User);
            var roles = await _userManeger.GetRolesAsync(user);
            if (user==null)
            {
                return Content("Kullanıcı bulunamadı.");
            }
            if (roles == null)
            {
                return Content("Roller bulunamadı.");
            }
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });


        }
    }
}
