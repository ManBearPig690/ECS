using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Entities;
using CocosSharp;
using ECS.Component;


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
        private const float MinXVelocity = -300;
        private const float MaxXVelocity = 300;

        public int Update(float dt, ref List<string> componentEntityList, float screenLeft, float screenRight, float minY)
        {
            // do collision logic
            // if ball and paddle colide reutrn 1
            // else 
            var ballSprite = EntityManager.Entities["Ball"].GetComponent<Component.SpriteComponent>().Sprite;
            var paddleSprite = EntityManager.Entities["Paddle"].GetComponent<Component.SpriteComponent>().Sprite;
            bool doesBallOverlapPaddle = ballSprite.BoundingBoxTransformedToParent.IntersectsRect(
                paddleSprite.BoundingBoxTransformedToParent);
            bool isFalling = EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityY < 0;

            if (doesBallOverlapPaddle && isFalling)
            {
                EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityY *= -1;
                EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityX = CCRandom.GetRandomFloat(MinXVelocity,
                    MaxXVelocity);
                return 1;
            }
            float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
            float ballLeft = ballSprite.BoundingBoxTransformedToParent.MinX;
            // Then let’s get the screen edges
            
            // Check if the ball is either too far to the right or left:    
            bool shouldReflectXVelocity =
                (ballRight > screenRight && EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityX > 0) ||
                (ballLeft < screenLeft && EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityX < 0);
            if (shouldReflectXVelocity)
            {
                EntityManager.Entities["Ball"].GetComponent<MotionComponent>().VelocityX *= -1;
            }

            if (ballSprite.PositionY < minY)
            {
                ballSprite.PositionX = 320;
                ballSprite.PositionY = 600;

                return -1;
            }
            return 0;
        }
    }
}
