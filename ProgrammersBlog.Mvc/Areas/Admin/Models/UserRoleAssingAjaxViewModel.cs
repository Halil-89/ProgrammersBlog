using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserRoleAssingAjaxViewModel
    {
        public UserRoleAssingDto UserRoleAssingDto { get; set; }
        public string RoleAssingPartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}
