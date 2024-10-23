using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomisableForms.Data;
using CustomisableForms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CustomisableForms.Controllers
{
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FormsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Forms
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        [Authorize(Roles = "User, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image_url,User_id," +
            "Topic_id,Custom_string1_state,Custom_string1_question,Custom_string2_state," +
            "Custom_string2_question,Custom_string3_state,Custom_string3_question,Custom_string4_state," +
            "Custom_string4_question,Custom_int1_state,Custom_int1_question,Custom_int2_state," +
            "Custom_int2_question,Custom_int3_state,Custom_int3_question,Custom_int4_state," +
            "Custom_int4_question")] Form form)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                form.Id = Guid.NewGuid();
                form.User_id = Guid.Parse(user.Id);
                form.Topic_id = Guid.NewGuid();

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile imageFile = Request.Form.Files.FirstOrDefault() ?? throw new FileNotFoundException("The uploaded file was not found.");
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    form.Image_url = "/images/" + fileName;
                }

                else
                {
                    form.Image_url = "/images/default.png";
                }

                Form.SetStringState(form);
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(form);
        }


        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Image_url,User_id," +
            "Topic_id,Custom_string1_state,Custom_string1_question,Custom_string2_state," +
            "Custom_string2_question,Custom_string3_state,Custom_string3_question,Custom_string4_state," +
            "Custom_string4_question,Custom_int1_state,Custom_int1_question,Custom_int2_state," +
            "Custom_int2_question,Custom_int3_state,Custom_int3_question,Custom_int4_state," +
            "Custom_int4_question")] Form form)
        {
            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(form);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form != null)
            {
                _context.Forms.Remove(form);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(Guid id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
