using FinialProject.Framework;
using FinialProject.Scenes;

namespace FinialProject
{
    //This part of the code inherit from the base class called MainGame
    //
    public class TetrisGame : MainGame
    {
        //This is  a constructor that intalzise the TetisGame class by calling the base class
        //With an instance of MainGameWindowSettings
        public TetrisGame() 
            :base(new MainGameWindowSettings
            {
                MouseVisible = true,
                Width = 25 * Constants.NumberOfTilesX + Constants.ScoreBoardWidth,
                Height = 25 * Constants.NumberOfTilesY,
                AllowUserResizing = false,
                IsFullScreen = false,
                Title = "Zubby#"

            })
        {
            AddScene<GameScene>("main", true);
        }
    }
}
