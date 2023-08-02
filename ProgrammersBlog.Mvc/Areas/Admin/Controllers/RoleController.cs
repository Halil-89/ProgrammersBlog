using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Text.Json;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _roleManager = roleManager;
        }

        [Authorize(Roles = "SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(new RoleListDto
            {
                Roles = roles
            });
        }


        [Authorize(Roles = "SuperAdmin,Role.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleListDto = JsonSerializer.Serialize(new RoleListDto
            {
                Roles = roles
            });
            return Json(roleListDto);
        }

        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpGet]
        public async Task<IActionResult> Assing(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await UserManager.GetRolesAsync(user);
            UserRoleAssingDto userRolesAssingDto = new UserRoleAssingDto
            {
                UserId = user.Id,
                UserName = user.UserName,
            };
            foreach (var role in roles)
            {
                RoleAssingDto roleAssingDto = new RoleAssingDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    HasRole = userRoles.Contains(role.Name)
                };
                userRolesAssingDto.RoleAssingDtos.Add(roleAssingDto);
            }
            return PartialView("_RoleAssingPartial", userRolesAssingDto);

        }
        [Authorize(Roles = "SuperAdmin,User.Update")]
        [HttpPost]
        public async Task<IActionResult> Assing(UserRoleAssingDto userRoleAssingDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userRoleAssingDto.UserId);
                foreach (var roleAssingDto in userRoleAssingDto.RoleAssingDtos)
                {
                    if (roleAssingDto.HasRole)
                    {
                        await UserManager.AddToRoleAsync(user, roleAssingDto.RoleName);
                    }
                    else
                    {
                        await UserManager.RemoveFromRoleAsync(user, roleAssingDto.RoleName);
                    }
                }
                await UserManager.UpdateSecurityStampAsync(user);
                var userRolesAssingAjaxViewModel = JsonSerializer.Serialize(new UserRoleAssingAjaxViewModel
                {
                    UserDto = new UserDto
                    {
                        User = user,
                        Message = $"{user.UserName} kullanıcısına ait rol atama işlemi başarıyla tamamlanmıştır.",
                        ResultStatus = ResultStatus.Succes
                    },
                    RoleAssingPartial = await this.RenderViewToStringAsync("_RoleAssingPartial", userRoleAssingDto)
                });
                return Json(userRolesAssingAjaxViewModel);

            }
            else
            {
                var userRoleAssingAjaxErrorModel = JsonSerializer.Serialize(new UserRoleAssingAjaxViewModel
                {
                    RoleAssingPartial=await this.RenderViewToStringAsync("_RoleAssingPartial",userRoleAssingDto),
                    UserRoleAssingDto=userRoleAssingDto
                });
                return Json(userRoleAssingAjaxErrorModel);
            }
        }

    }
}
   


