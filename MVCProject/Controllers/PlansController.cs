﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PlansController : Controller
    {
        private readonly MVCProjectContext _context;

        public PlansController(MVCProjectContext context)
        {
            _context = context;
        }

        // GET: Plans
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public async Task<IActionResult> Index(string sortOrder,string searchString, string currentFilter)
        {
            if (_context.Plan == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            if (searchString.IsNullOrEmpty())
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            ViewBag.OwnerSortParm = sortOrder == "Owner" ? "owner_desc" : "Owner";
            ViewBag.DateUpdatedSortParm = sortOrder == "DateUpdated" ? "dateupdated_desc" : "DateUpdated";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.UpdatedBySortParm = sortOrder == "UpdatedBy" ? "updatedby_desc" : "UpdatedBy";

            var plan = from m in _context.Plan
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (Int32.TryParse(searchString, out int j))
                {
                    plan = plan.Where(s => s.Id!.Equals(j));
                }
                else {
                    plan = plan.Where(s => s.Name!.Contains(searchString));
                }
               
            }

            switch (sortOrder)
            {
                case "name_desc":
                    plan = plan.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    plan = plan.OrderBy(s => s.CreatedAt);
                    break;
                case "DateUpdated":
                    plan = plan.OrderBy(s => s.UpdatedAt);
                    break;
                case "Id":
                    plan = plan.OrderBy(s => s.Id);
                    break;
                case "Owner":
                    plan = plan.OrderBy(s => s.Owner);
                    break;
                case "Status":
                    plan = plan.OrderBy(s => s.Status);
                    break;
                case "UpdatedBy":
                    plan = plan.OrderBy(s => s.UpdatedBy);
                    break;
                case "date_desc":
                    plan = plan.OrderByDescending(s => s.CreatedAt);
                    break;
                case "dateupdated_desc":
                    plan = plan.OrderByDescending(s => s.UpdatedAt);
                    break;
                case "id_desc":
                    plan = plan.OrderByDescending(s => s.Id);
                    break;
                case "owner_desc":
                    plan = plan.OrderByDescending(s => s.Owner);
                    break;
                case "status_desc":
                    plan = plan.OrderByDescending(s => s.Status);
                    break;
                case "updatedby_desc":
                    plan = plan.OrderByDescending(s => s.UpdatedBy);
                    break;
                default:
                    plan = plan.OrderBy(s => s.Name);
                    break;
            }

            return View(await plan.ToListAsync());
        }

        // GET: Plans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // **
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Plan plan)
        {
         
            if (ModelState.IsValid)
            {
                var dbPost = new Plan
                {
                    Id = plan.Id,
                    Name = plan.Name,
                    Owner = plan.Owner,
                    Status = plan.Status,
                    UpdatedBy = plan.UpdatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

           
                _context.Add(dbPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: Plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Plan plan)
        {

            if (id != plan.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
               
                try
                {
                    var dbPost = _context.Plan.Find(id);

                    dbPost!.Id = plan.Id;
                    dbPost.Name = plan.Name;
                    dbPost.Owner = plan.Owner;
                    dbPost.Status = plan.Status;
                    dbPost.UpdatedBy = plan.UpdatedBy;
                    dbPost.UpdatedAt = DateTime.Now;
                
                    _context.Update(dbPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.Id))
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
            return View(plan);
        }

        // GET: Plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plan == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plan == null)
            {
                return Problem("Entity set 'MVCProjectContext.Plan'  is null.");
            }
            var plan = await _context.Plan.FindAsync(id);
            if (plan != null)
            {
                _context.Plan.Remove(plan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanExists(int id)
        {
          return (_context.Plan?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
