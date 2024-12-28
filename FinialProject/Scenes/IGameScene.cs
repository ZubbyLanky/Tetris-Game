using FinialProject.Models;
using FinialProject.Framework.Scenes;


namespace FinialProject.Scenes
{
    internal interface IGameScene : IScene
    {
        GameBoard GameBoard { get; }
    }
}
