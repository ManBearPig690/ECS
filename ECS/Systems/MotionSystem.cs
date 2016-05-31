using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Component;
using ECS.Entities;

namespace ECS.Systems
{
    public class MotionSystem : System
    {


        // might need to set frame rate/ update in secons some where get how many animation frames
        public override void Update(float dt, ref List<string> componentEntityList)
        {
            foreach (var entityId in componentEntityList)
            {
                if (EntityManager.Entities[entityId].GetComponent<MotionComponent>().Gravity != 0f)
                {
                    EntityManager.Entities[entityId].GetComponent<MotionComponent>().VelocityY += dt*
                                                                                    -EntityManager.Entities[entityId]
                                                                                        .GetComponent<MotionComponent>()
                                                                                        .Gravity;
                }
                EntityManager.Entities[entityId].GetComponent<PositionComponent>().PositionX += EntityManager.Entities[entityId].GetComponent<MotionComponent>().VelocityX * dt; 
                EntityManager.Entities[entityId].GetComponent<PositionComponent>().PositionY += EntityManager.Entities[entityId].GetComponent<MotionComponent>().VelocityY * dt;
            }
        }


    }
}
