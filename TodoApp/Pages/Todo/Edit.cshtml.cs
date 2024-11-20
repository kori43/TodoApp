using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.Todo
{
    public class EditModel : PageModel
    {
        private readonly TodoApp.Data.TodoAppContext _context;

        public EditModel(TodoApp.Data.TodoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDos ToDos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todos =  await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
            if (todos == null)
            {
                return NotFound();
            }
            ToDos = todos;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDosExists(ToDos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDosExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
