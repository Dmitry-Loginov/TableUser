using Ex4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ex4.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(_userManager.Users.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Delete(string ids)
        {
            if(ids == null)
                return Redirect("Index");
            string[] idsSplit = ids.Split(',');
            Models.User[] users = new User[idsSplit.Length];
            for(int i = 0; i< idsSplit.Length; i++)
            {
                 users[i] = _userManager.FindByIdAsync(idsSplit[i]).Result;
            }

            for (int i = 0; i < idsSplit.Length; i++)
            {
                _userManager.DeleteAsync(users[i]);
            }
            return Redirect("Index");
        }
    }
}
