﻿using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
      

    }
}
