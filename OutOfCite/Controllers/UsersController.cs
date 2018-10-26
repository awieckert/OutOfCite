﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OutOfCite.Data;
using OutOfCite.Models;

namespace OutOfCite.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Users
        public async Task<IActionResult> Index()
        {

            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();

            return View(currentUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit()
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();

            return View(currentUser);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = new PasswordHasher<ApplicationUser>();

                ApplicationUser currentUser = await GetCurrentUserAsync();
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.NormalizedEmail = user.Email.ToUpper();
                currentUser.UserName = user.Email;
                currentUser.NormalizedUserName = user.Email.ToUpper();
                currentUser.LinkedIn = user.LinkedIn;
                currentUser.PasswordHash = passwordHash.HashPassword(currentUser, user.PasswordHash);

                await _userManager.UpdateAsync(currentUser);
                return RedirectToAction("Details");
            }
            return RedirectToAction("Edit");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}