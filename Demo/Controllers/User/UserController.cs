using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Demo.Models.DataModel.User;
using Demo.Models.ViewModel;

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            userService = new UserService(userManager, signInManager);
        }

        // GET: UserEntities
        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Profile", new { id=User.Identity.Name });
        }

        [Authorize]
        public async Task<IActionResult> Profile(string id)
        {
            UserEntity user = await userService.Get(id);
            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            UserEntity user = await userService.Get(id);
            return View("EditProfile", user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEntity model, string id)
        {
            UserEntity user = await userService.Get(id);
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            bool result = await userService.UpdateAsync(user);
            if(result)
                return View("EditProfile", user);
            ModelState.AddModelError("", "Error occurs while editing your profile");
            return View("EditProfile", user);
        }

        /*
        // GET: UserEntities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // GET: UserEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password,Ip,LastLogin,RegDate,RegIp,Email,Session")] UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEntity);
        }

        // GET: UserEntities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            return View(userEntity);
        }

        // POST: UserEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Password,Ip,LastLogin,RegDate,RegIp,Email,Session")] UserEntity userEntity)
        {
            if (id != userEntity.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEntityExists(userEntity.UserName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userEntity);
        }

        // GET: UserEntities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEntity = await _context.User
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // POST: UserEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userEntity = await _context.User.FindAsync(id);
            _context.User.Remove(userEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEntityExists(string id)
        {
            return _context.User.Any(e => e.UserName == id);
        }
        */
    }
}
