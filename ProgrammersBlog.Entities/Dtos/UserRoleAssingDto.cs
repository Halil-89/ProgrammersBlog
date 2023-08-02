using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserRoleAssingDto
    {
        public UserRoleAssingDto()
        {
            RoleAssingDtos=new List<RoleAssingDto>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssingDto> RoleAssingDtos { get; set; }
    }
}
