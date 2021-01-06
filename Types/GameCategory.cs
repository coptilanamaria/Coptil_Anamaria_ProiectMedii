using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coptil_Anamaria_ProiectMedii.Types
{
    public class GameCategory
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
