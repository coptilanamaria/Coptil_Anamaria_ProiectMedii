using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coptil_Anamaria_ProiectMedii.Types
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
