using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactsManagementApplication.Data;
using ContactsManagementApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ContactsManagementApplication.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ContactsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
              return _context.ContactsInfo != null ? 
                          View(await _context.ContactsInfo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.ContactsInfo'  is null.");
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactsInfo == null)
            {
                return NotFound();
            }

            var contactsEntity = await _context.ContactsInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsEntity == null)
            {
                return NotFound();
            }

            return View(contactsEntity);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] ContactsEntity contactsEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactsEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactsEntity);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactsInfo == null)
            {
                return NotFound();
            }

            var contactsEntity = await _context.ContactsInfo.FindAsync(id);
            if (contactsEntity == null)
            {
                return NotFound();
            }
            return View(contactsEntity);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] ContactsEntity contactsEntity)
        {
            if (id != contactsEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactsEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsEntityExists(contactsEntity.Id))
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
            return View(contactsEntity);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactsInfo == null)
            {
                return NotFound();
            }

            var contactsEntity = await _context.ContactsInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsEntity == null)
            {
                return NotFound();
            }

            return View(contactsEntity);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactsInfo == null)
            {
                return Problem("Entity set 'ApplicationDBContext.ContactsInfo'  is null.");
            }
            var contactsEntity = await _context.ContactsInfo.FindAsync(id);
            if (contactsEntity != null)
            {
                _context.ContactsInfo.Remove(contactsEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactsEntityExists(int id)
        {
          return (_context.ContactsInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
