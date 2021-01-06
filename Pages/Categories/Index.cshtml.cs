using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coptil_Anamaria_ProiectMedii.Data;
using Coptil_Anamaria_ProiectMedii.Types;

namespace Coptil_Anamaria_ProiectMedii.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext _context;

        public IndexModel(Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
