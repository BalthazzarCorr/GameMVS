﻿namespace MyGameStoreApp.Controllers
{
   using SimpleMvc.Framework.Contracts;

   public class HomeController:BaseController
    {
       public IActionResult Index()
       {
          return this.View();
       }
    }
}
