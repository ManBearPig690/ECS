using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Entities;
using CocosSharp;

namespace ECS.Systems
{
    /// <summary>
    /// gets enties with collision component 
    /// checks for bounding box rules
    /// does collsion logic
    /// 
    /// </summary>
    public class CollisionSystem : System
    {
        public new int Update(float dt, ref Dictionary<string, Entity> entities, ref List<string> componentEntityList)
        {
            // do collision logic
            // if ball and paddle colide reutrn 1
            // else 
            var ballSprite = entities["Ball"].GetComponent<Component.SpriteComponent>().Sprite;
            var paddleSprite = entities["Paddle"].GetComponent<Component.SpriteComponent>().Sprite;
            bool doesBallOverlapPaddle = ballSprite.BoundingBoxTransformedToParent.IntersectsRect(
                paddleSprite.BoundingBoxTransformedToParent);



            return 0;
        }
    }
}
