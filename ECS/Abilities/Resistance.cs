using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Abilities
{
    public class Resistance
    {
        public ResistanceType ResistanceType { get; set; }
    }

    public enum ResistanceType
    {
        Poison,
        Fire,
        Cold
    }
}
