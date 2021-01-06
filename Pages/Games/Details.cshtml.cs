using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coptil_Anamaria_ProiectMedii.Data;
using Coptil_Anamaria_ProiectMedii.Types;

namespace Coptil_Anamaria_ProiectMedii.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext _context;

        public DetailsModel(Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
