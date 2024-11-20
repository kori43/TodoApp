using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Pages.Todo
{
    public class CreateModel : PageModel
    {
        private readonly TodoApp.Data.TodoAppContext _context;

        public CreateModel(TodoApp.Data.TodoAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDos ToDos { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDos.Add(ToDos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
