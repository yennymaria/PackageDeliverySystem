﻿using System.Web;
using System.Web.Mvc;

namespace PackageDelivery.GUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
