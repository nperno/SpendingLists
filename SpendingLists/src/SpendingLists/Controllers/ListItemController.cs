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
    public class ListItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListItemController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ListItem
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListItems.Include(l => l.SpendingList);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItems.SingleOrDefaultAsync(m => m.Id == id);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        // GET: ListItem/Create
        public IActionResult Create()
        {
            ViewData["SpendingListId"] = new SelectList(_context.SpendingLists, "Id", "Owner");
            return View();
        }

        // POST: ListItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cost,Link,Name,SpendingListId")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SpendingListId"] = new SelectList(_context.SpendingLists, "Id", "Owner", listItem.SpendingListId);
            return View(listItem);
        }

        // GET: ListItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItems.SingleOrDefaultAsync(m => m.Id == id);
            if (listItem == null)
            {
                return NotFound();
            }
            ViewData["SpendingListId"] = new SelectList(_context.SpendingLists, "Id", "Owner", listItem.SpendingListId);
            return View(listItem);
        }

        // POST: ListItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cost,Link,Name,SpendingListId")] ListItem listItem)
        {
            if (id != listItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListItemExists(listItem.Id))
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
            ViewData["SpendingListId"] = new SelectList(_context.SpendingLists, "Id", "Owner", listItem.SpendingListId);
            return View(listItem);
        }

        // GET: ListItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listItem = await _context.ListItems.SingleOrDefaultAsync(m => m.Id == id);
            if (listItem == null)
            {
                return NotFound();
            }

            return View(listItem);
        }

        // POST: ListItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listItem = await _context.ListItems.SingleOrDefaultAsync(m => m.Id == id);
            _context.ListItems.Remove(listItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ListItemExists(int id)
        {
            return _context.ListItems.Any(e => e.Id == id);
        }
    }
}
