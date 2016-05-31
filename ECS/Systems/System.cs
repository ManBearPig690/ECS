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
        public virtual void Update(float dt, ref List<string> componentEntityList){}
        //public virtual void Init() { }

        public System()
        {
            
        }
    }
}
