

namespace FinialProject.Framework
{
    public sealed class MainGameWindowSettings
    {
        public static readonly MainGameWindowSettings FullScreen = new MainGameWindowSettings
        {
            IsFullScreen = true
        };

        public static readonly MainGameWindowSettings NormalScreenShowMouse = new MainGameWindowSettings
        {
            IsFullScreen = false,
            Width = 1024,
            Height = 768,
            MouseVisible = true,
            AllowUserResizing = true
        };

        public static readonly MainGameWindowSettings NormalScreenNoMouse = new MainGameWindowSettings
        {
            IsFullScreen = false,
            Width = 1024,
            Height = 768,
            MouseVisible = false,
            AllowUserResizing = true
        };

        public static readonly MainGameWindowSettings NormalScreenShowMouseFixed = new MainGameWindowSettings
        {
            IsFullScreen = false,
            Width = 1024,
            Height = 768,
            MouseVisible = true,
            AllowUserResizing = false
        };

        public static readonly MainGameWindowSettings NormalScreenNoMouseFixed = new MainGameWindowSettings
        {
            IsFullScreen = false,
            Width = 1024,
            Height = 768,
            MouseVisible = false,
            AllowUserResizing = false
        };


        public bool IsFullScreen { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool MouseVisible { get; set; }

        public bool AllowUserResizing { get; set; }

        public string Title { get; set; }
    }
}
