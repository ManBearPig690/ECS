using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CocosSharp;


namespace ECS
{
    public class Engine
    {

        private static readonly GameLayer GameLayer = new GameLayer();

        public void LoadGame(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            if (gameView != null)
            {
                var contentSearchPaths = new List<string>(){"Fonts", "Sounds"};
                var viewSize = gameView.ViewSize;

                int width = 768;
                int height = 1027;

                gameView.DesignResolution = new CCSizeI(width, height);

                if (width < viewSize.Width)
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
