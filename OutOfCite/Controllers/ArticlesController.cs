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
using OutOfCite.Models.ViewModels;

namespace OutOfCite.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ArticlesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Articles
        public async Task<IActionResult> Index(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArticleIndexViewModel articleIndex = new ArticleIndexViewModel(_context, id); 

            return View(articleIndex);
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Affiliation)
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        public async Task<IActionResult> Favorite (int id)
        {
            var currentUser = await GetCurrentUserAsync();
            string currentUserId = currentUser.Id;
            var checkIfFavorited = _context.FavoriteArticles.Where(x => x.ApplicationUserId == currentUserId && x.ArticleId == id).Count();

            if (checkIfFavorited == 0)
            {
                FavoriteArticle newFavorite = new FavoriteArticle()
                {
                    ApplicationUserId = currentUserId,
                    ArticleId = id
                };

                _context.Add(newFavorite);
                await _context.SaveChangesAsync();
                return RedirectToAction("MainPage", "Home");
            }

            return View();
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["AffiliationId"] = new SelectList(_context.Affiliations, "Id", "Id");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorId,AffiliationId,Title,Abstract,URL,Journal,JournalImpact,Citations")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AffiliationId"] = new SelectList(_context.Affiliations, "Id", "Id", article.AffiliationId);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", article.AuthorId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["AffiliationId"] = new SelectList(_context.Affiliations, "Id", "Id", article.AffiliationId);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", article.AuthorId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,AffiliationId,Title,Abstract,URL,Journal,JournalImpact,Citations")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            ViewData["AffiliationId"] = new SelectList(_context.Affiliations, "Id", "Id", article.AffiliationId);
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "FirstName", article.AuthorId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Affiliation)
                .Include(a => a.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}
