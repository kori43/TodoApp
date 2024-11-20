using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.Todo
{
    public class DeleteModel : PageModel
    {
        private readonly TodoApp.Data.TodoAppContext _context;

        public DeleteModel(TodoApp.Data.TodoAppContext context)
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

            var todos = await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);

            if (todos == null)
            {
                return NotFound();
            }
            else
            {
                ToDos = todos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todos = await _context.ToDos.FindAsync(id);
            if (todos != null)
            {
                ToDos = todos;
                _context.ToDos.Remove(ToDos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
