#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_CRUD__ef_core_class_first_.Data;
using Razor_Pages_CRUD__ef_core_class_first_.Entities;

namespace Razor_Pages_CRUD__ef_core_class_first_.Pages.CRUD
{
    public class DetailsModel : PageModel
    {
        private readonly Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext _context;

        public DetailsModel(Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext context)
        {
            _context = context;
        }

        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers.FirstOrDefaultAsync(m => m.Id == id);

            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
