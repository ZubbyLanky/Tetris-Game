using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FinialProject.Framework.Messaging;
using FinialProject.Framework.Scenes;
using System;
using System.Collections.Generic;


namespace FinialProject.Framework
{
    public class MainGame : Game, IMainGame
    {
        #region Protected Fields

        protected SpriteBatch spriteBatch;

        #endregion Protected Fields

        #region Private Fields

        private static readonly object sync = new object();
        private readonly GraphicsDeviceManager graphicsDeviceManager;
        // private readonly List<IScene> scenes = new List<IScene>();
        private readonly Dictionary<string, IScene> scenes = new Dictionary<string, IScene>();
        private readonly MainGameWindowSettings windowSettings;
        private bool disposed = false;

        // private int sceneIndex = 0;

        #endregion Private Fields

        #region Public Constructors

        public MainGame()
            : this(MainGameWindowSettings.NormalScreenShowMouse)
        { }

        public MainGame(MainGameWindowSettings windowSettings)
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            this.windowSettings = windowSettings;
            Content.RootDirectory = "Content";

            this.MessageDispatcher.RegisterHandler<SceneEndedMessage>((publisher, message) =>
            {
                lock (sync)
                {
                    ActiveScene?.Leave();

                    ActiveScene = ActiveScene.Next;

                    if (ActiveScene == null)
                    {
                        Exit();
                        return;
                    }

                    ActiveScene?.Enter();
                }
            });
        }

        #endregion Public Constructors

        #region Public Properties

        public IScene ActiveScene { get; set; }

        public int Count => scenes.Count;

        public bool IsReadOnly => false;

        public IMessageDispatcher MessageDispatcher { get; } = new MessageDispatcher();

        #endregion Public Properties

        #region Public Methods

        public void AddScene(string name, IScene item, bool isEntryScene = false)
        {
            if (isEntryScene)
            {
                if (ActiveScene == null)
                {
                    ActiveScene = item;
                }
                else
                {
                    throw new InvalidOperationException("There is already a scene that is marked as the entry scene.");
                }
            }

            this.scenes.Add(name, item);
        }

        #endregion Public Methods

        #region Protected Methods

        protected void AddScene<TScene>(string name, bool isEntryScene = false)
            where TScene : Scene
            => AddScene(name, (TScene)Activator.CreateInstance(typeof(TScene), this), isEntryScene);

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    foreach (var kvp in scenes)
                    {
                        kvp.Value.Dispose();
                    }
                }

                base.Dispose(disposing);
                disposed = true;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            this.spriteBatch.Begin();

            ActiveScene?.Draw(gameTime, this.spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            if (!string.IsNullOrEmpty(windowSettings.Title))
            {
                this.Window.Title = windowSettings.Title;
            }

            if (this.scenes?.Count == 0 || this.ActiveScene == null)
            {
                throw new InvalidOperationException("No active scene has been defined.");
            }

            graphicsDeviceManager.IsFullScreen = this.windowSettings.IsFullScreen;
            if (!this.windowSettings.IsFullScreen)
            {
                graphicsDeviceManager.PreferredBackBufferWidth = this.windowSettings.Width;
                graphicsDeviceManager.PreferredBackBufferHeight = this.windowSettings.Height;
            }
            else
            {
                graphicsDeviceManager.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                graphicsDeviceManager.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            }

            Window.AllowUserResizing = this.windowSettings.AllowUserResizing;
            this.IsMouseVisible = this.windowSettings.MouseVisible;
            graphicsDeviceManager.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var kvp in this.scenes)
            {
                kvp.Value.Load(Content);
            }

            ActiveScene?.Enter();
        }

        protected override void Update(GameTime gameTime)
        {
            ActiveScene?.Update(gameTime);

            base.Update(gameTime);
        }

        public IScene GetSceneByName(string sceneName) => scenes[sceneName];

        #endregion Protected Methods
    }
}
