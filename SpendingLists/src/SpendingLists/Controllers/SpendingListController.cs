using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpendingLists.Data;
using SpendingLists.Models;
using Microsoft.AspNetCore.Authorization;

namespace SpendingLists.Controllers
{
    [Authorize]
    public class SpendingListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpendingListController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SpendingList
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpendingLists.ToListAsync());
        }

        // GET: SpendingList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingList = await _context.SpendingLists.SingleOrDefaultAsync(m => m.Id == id);
            if (spendingList == null)
            {
                return NotFound();
            }

            return View(spendingList);
        }

        // GET: SpendingList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpendingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Funds,Name")] SpendingList spendingList)
        {
            if (ModelState.IsValid)
            {
                spendingList.Owner = User.Identity.Name;
                _context.Add(spendingList);
                 _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spendingList);
        }

        // GET: SpendingList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingList = await _context.SpendingLists.SingleOrDefaultAsync(m => m.Id == id);
            if (spendingList == null)
            {
                return NotFound();
            }
            return View(spendingList);
        }

        // POST: SpendingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Funds,Name")] SpendingList spendingList)
        {
            if (id != spendingList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (spendingList.Owner == null) { spendingList.Owner = User.Identity.Name; }
                    _context.Update(spendingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpendingListExists(spendingList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(spendingList);
        }

        // GET: SpendingList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingList = await _context.SpendingLists.SingleOrDefaultAsync(m => m.Id == id);
            if (spendingList == null)
            {
                return NotFound();
            }

            return View(spendingList);
        }

        // POST: SpendingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spendingList = await _context.SpendingLists.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpendingLists.Remove(spendingList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpendingListExists(int id)
        {
            return _context.SpendingLists.Any(e => e.Id == id);
        }
    }
}
