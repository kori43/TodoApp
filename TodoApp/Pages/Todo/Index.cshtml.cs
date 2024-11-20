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
    public class IndexModel : PageModel
    {
        private readonly TodoApp.Data.TodoAppContext _context;

        public IndexModel(TodoApp.Data.TodoAppContext context)
        {
            _context = context;
        }

        public IList<ToDos> ToDos { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ToDos = await _context.ToDos.ToListAsync();
        }
    }
}
