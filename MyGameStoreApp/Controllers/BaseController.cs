namespace MyGameStoreApp.Controllers
{
   using System.Linq;
   using Data;
   using SimpleMvc.Framework.Controllers;

   public abstract class BaseController : Controller
   {
      protected BaseController()
      {
         this.ViewModel["anonymousDisplay"] = "flex";
         this.ViewModel["userDisplay"] = "none";
         this.ViewModel["adminDisplay"] = "none";
         this.ViewModel["show-error"] = "none";
      }


      protected void ShowError(string error)
      {
         this.ViewModel["show-error"] = "flex";
         this.ViewModel["error"] = error;
      }

      protected override void  InitializeController()
      {
         base.InitializeController();

         if (this.User.IsAuthenticated)
         {
            this.ViewModel["anonymousDisplay"] = "none";
            this.ViewModel["userDisplay"] = "flex";
            using (var db = new GameStoreDbContext())
            {
               var isAdmin = db.Users.Any(u => u.Email == this.User.Name && u.IsAdmin);


               if (isAdmin)
               {
                  this.ViewModel["userDisplay"] = "none";
                  this.ViewModel["adminDisplay"] = "block";
               }
            }


         }
      }
   }
}
