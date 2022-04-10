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
    public class IndexModel : PageModel
    {

        private readonly Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext _context;

        public IndexModel(Razor_Pages_CRUD__ef_core_class_first_.Data.WorkerDbContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; }


        [BindProperty]
        public Worker _Worker { get; set; }

        [BindProperty(SupportsGet = true)]
        public string search { get; set; }

        public async Task OnGetAsync()
        {
            var result = string.IsNullOrEmpty(search) ? _context.Workers.ToListAsync() : _context.Workers.Where(s => s.Name.Contains(search)).ToListAsync();
           
            Worker = await result;


        }

        public async Task<IActionResult> OnPost()
        {
            await _context.Workers.AddAsync(_Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index", _Worker);
        }
    }
}
