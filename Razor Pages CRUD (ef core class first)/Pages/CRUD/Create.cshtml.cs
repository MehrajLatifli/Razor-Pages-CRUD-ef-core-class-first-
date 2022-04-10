#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_Pages_CRUD__ef_core_class_first_.Data;
using Razor_Pages_CRUD__ef_core_class_first_.Entities;

namespace Razor_Pages_CRUD__ef_core_class_first_.Pages.CRUD
{
    public class CreateModel : PageModel
    {
        private readonly Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext _context;

        public CreateModel(Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
