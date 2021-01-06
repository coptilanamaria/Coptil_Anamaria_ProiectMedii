using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Coptil_Anamaria_ProiectMedii.Data;

namespace Coptil_Anamaria_ProiectMedii.Types
{
    public class GameCategoriesPageType : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Coptil_Anamaria_ProiectMediiContext context,Game game)
        {
            var allCategories = context.Category;
            var gameCategories = new HashSet<int>(game.GameCategories.Select(c => c.GameID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID, Name = cat.CategoryName, Assigned = gameCategories.Contains(cat.ID) });
            }
        }
        public void UpdateGameCategories(Coptil_Anamaria_ProiectMediiContext context, string[] selectedCategories, Game gameToUpdate)
        {
            if (selectedCategories == null)
            {
                gameToUpdate.GameCategories = new List<GameCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var gameCategories = new HashSet<int>
            (gameToUpdate.GameCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!gameCategories.Contains(cat.ID))
                    {
                        gameToUpdate.GameCategories.Add(
                        new GameCategory
                        {
                            GameID = gameToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (gameCategories.Contains(cat.ID))
                    {
                        GameCategory courseToRemove = gameToUpdate.GameCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

