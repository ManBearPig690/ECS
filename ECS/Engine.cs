using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Box2D.Dynamics;
using CocosSharp;


namespace ECS
{
    public class Engine
    {
        // this can alos hold some global data for transitioning between layers
        //...like player data so it is not lost if all entities are cleared from the game layer
        // when loading a new level


        private const int Width = 768;
        private const int Height = 1027;
        private static readonly GameLayer GameLayer = new GameLayer(Width, Height);
        

        public void LoadGame(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            
            if (gameView != null)
            {
                var contentSearchPaths = new List<string>(){"Fonts", "Sounds"};
                var viewSize = gameView.ViewSize;

                

                gameView.DesignResolution = new CCSizeI(Width, Height);

                if (Width < viewSize.Width)
                {
                    contentSearchPaths.Add("Images/Hd");
                    CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
                }
                else
                {
                    contentSearchPaths.Add("Images/Ld");
                    CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
                }

                gameView.ContentManager.SearchPaths = contentSearchPaths;
                var gameScene = new CCScene(gameView);
                gameScene.AddLayer(GameLayer);
                gameView.RunWithScene(gameScene);
            }
        }
    }
}
