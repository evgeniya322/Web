﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WStore.Components
{
    public class UserInfoViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke() => User.Identity.IsAuthenticated
            ? View("UserInfoView")
            : View();
    }
}
