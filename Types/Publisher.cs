using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coptil_Anamaria_ProiectMedii.Types
{
    public class Publisher
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Game> Game { get; set; } //navigation property
    }

    }

