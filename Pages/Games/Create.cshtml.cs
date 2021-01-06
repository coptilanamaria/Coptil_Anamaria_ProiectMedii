﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coptil_Anamaria_ProiectMedii.Data;
using Coptil_Anamaria_ProiectMedii.Types;

namespace Coptil_Anamaria_ProiectMedii.Pages.Games
{
    public class CreateModel : GameCategoriesPageType
    {
        private readonly Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext _context;

        public CreateModel(Coptil_Anamaria_ProiectMedii.Data.Coptil_Anamaria_ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var game = new Game();
            game.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, game);

            return Page();
        }


        [BindProperty]
        public Game Game { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newGame = new Game();
            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Game>(
            newGame,
            "Game",
            i => i.Name, i => i.Creator,
            i => i.Price, i => i.ReleaseDate, i => i.PublisherID))
            {
                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newGame);
            return Page();
        }
    }
}