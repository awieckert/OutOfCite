using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutOfCite.Data;
using OutOfCite.Models;

namespace OutOfCite.Controllers
{
    public class AffiliationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public AffiliationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Affiliations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Affiliations.ToListAsync());
        }

        // GET: Affiliations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (affiliation == null)
            {
                return NotFound();
            }

            return View(affiliation);
        }

        // GET: Affiliations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Affiliations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Affiliation affiliation)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = (await GetCurrentUserAsync()).Id;


                var checkIfExists = _context.Affiliations.Where(x => x.Name.ToLower() == affiliation.Name.ToLower()).SingleOrDefault();

                if (checkIfExists != null)
                {
                    UserAffiliation newUserAffiliation = new UserAffiliation()
                    {
                        AffiliationId = checkIfExists.Id,
                        ApplicationUserId = currentUserId
                    };

                    _context.Add(newUserAffiliation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MainPage", "Home");
                } else
                {
                    Affiliation newAffiliation = new Affiliation()
                    {
                        Name = affiliation.Name
                    };

                    _context.Add(newAffiliation);
                    await _context.SaveChangesAsync();

                    //var theNewAffiliation = (from a in _context.Affiliations
                    //                        where a.Name == affiliation.Name
                    //                        select a).SingleOrDefault();

                    UserAffiliation newUserAffiliation = new UserAffiliation()
                    {
                        AffiliationId = newAffiliation.Id,
                        ApplicationUserId = currentUserId
                    };

                    _context.Add(newUserAffiliation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("MainPage", "Home");
                }
            }
            return View(affiliation);
        }

        // GET: Affiliations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations.FindAsync(id);
            if (affiliation == null)
            {
                return NotFound();
            }
            return View(affiliation);
        }

        // POST: Affiliations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Affiliation affiliation)
        {
            if (id != affiliation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(affiliation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffiliationExists(affiliation.Id))
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
            return View(affiliation);
        }

        // GET: Affiliations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliation = await _context.Affiliations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (affiliation == null)
            {
                return NotFound();
            }

            return View(affiliation);
        }

        // POST: Affiliations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var affiliation = await _context.Affiliations.FindAsync(id);
            _context.Affiliations.Remove(affiliation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AffiliationExists(int id)
        {
            return _context.Affiliations.Any(e => e.Id == id);
        }
    }
}
