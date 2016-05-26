using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECS.Entities;

namespace ECS.Systems
{
    public class System
    {        
        public virtual void Update(int dt){}
        public virtual void Init() { }

        public static Dictionary<string, Entity> EntityList { get; set; }

        public System()
        {
            EntityList = new Dictionary<string, Entity>();
        }
    }
}
