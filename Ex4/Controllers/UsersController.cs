﻿using Ex4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ex4.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Delete(string ids)
        {
            if(ids == null)
                return Redirect("Index");
            string[] idsSplit = ids.Split(',');
            var currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (idsSplit.Contains(currentUser.Id))
            {
                await _signInManager.SignOutAsync();
            }
            Models.User[] users = new User[idsSplit.Length];
            for(int i = 0; i< idsSplit.Length; i++)
            {
                 users[i] = _userManager.FindByIdAsync(idsSplit[i]).Result;
            }

            for (int i = 0; i < idsSplit.Length; i++)
            {
                await _userManager.DeleteAsync(users[i]);
            }
            return Redirect("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> Block(string ids)
        {
            if(ids == null)
                return Redirect("Index");
            var currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            string[] idsSplit = ids.Split(',');
            if (idsSplit.Contains(currentUser.Id))
            {
                await _signInManager.SignOutAsync();
            }
            Models.User[] users = new User[idsSplit.Length];
            for(int i = 0; i< idsSplit.Length; i++)
            {
                 users[i] = _userManager.FindByIdAsync(idsSplit[i]).Result;
            }

            for (int i = 0; i < idsSplit.Length; i++)
            {
                users[i].Status = Status.Block;
                await _userManager.UpdateAsync(users[i]);
            }
            return Redirect("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> Unblock(string ids)
        {
            if(ids == null)
                return Redirect("Index");
            string[] idsSplit = ids.Split(',');
            Models.User[] users = new User[idsSplit.Length];
            for(int i = 0; i< idsSplit.Length; i++)
            {
                users[i] =  _userManager.FindByIdAsync(idsSplit[i]).Result;
            }

            for (int i = 0; i < idsSplit.Length; i++)
            {
                users[i].Status = Status.Active;
                await _userManager.UpdateAsync(users[i]);
            }
            return Redirect("Index");
        }
    }
}
