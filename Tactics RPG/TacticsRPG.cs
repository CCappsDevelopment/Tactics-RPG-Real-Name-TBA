using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using TacticsRPG_GameEngine;
using TacticsRPG_GameEngine.Tilemaps;

// BEGIN TacticsRPG
namespace Tactics_RPG
{
	/// <summary>
	/// Tactics RPG (Proof of Concept)
	/// Create tile based map that shows movement data for a
	/// player character when a single tile is clicked.
	/// </summary>
	public class TacticsRPG : Game
	{ 
		public GraphicsDeviceManager graphics; // Handles display output settings
		public SpriteBatch spriteBatch; // Group of sprites to be drawn
		public Map worldMap; // Tile Map used for the level currently displayed
		private OrthographicCamera camera; // Viewport for game content

		/// <summary>
		/// TacticsRPG() - Constructor
		/// Initializes graphics device manager, sets default content directory
		/// </summary>
		public TacticsRPG()
		{
			graphics = new GraphicsDeviceManager(this); // Initialize graphics device manager
			Content.RootDirectory = "Content"; // set default content directory for game assets

			IsMouseVisible = true; // Show mouse cursor within the window
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// Set window size via the graphics device manager
			graphics.PreferredBackBufferWidth = 1280;
			graphics.PreferredBackBufferHeight = 720;

			graphics.ApplyChanges(); // Save changes to graphics device manager

			base.Initialize(); // Call Monogame/XNA built-in Initialize() method
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			worldMap = new Map(32, 32, 16, 16); // Initialize new game map
			camera = new OrthographicCamera(GraphicsDevice); // Initialize main camera
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// if the escape key on the keyboard or the 
			// 'back' button of in-use game controller is pressed, 
			// close the game window.
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Update Logic //
			var gTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			var kstate = Keyboard.GetState(); // variable for current keyboard state (keys pressed) 
			Vector2 moveVelocity = Vector2.Zero; // Set default movement velocity to 0

			// Handle user input
			// Currently increases movement velocity in specific direction (Up, Down, Left, Right)
			// depending on directional key press (also WASD)
			#region User Input
			if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
				moveVelocity += new Vector2(0, -1);
			if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
				moveVelocity += new Vector2(0, 1);
			if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
				moveVelocity += new Vector2(-1, 0);
			if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
				moveVelocity += new Vector2(1, 0);
			#endregion

			// Pans the game camera with the speed/direction of the movement velocity 
			camera.Move(moveVelocity);

            base.Update(gameTime); // Call Monogame/XNA built-in Update method
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			// Clear screen each tick to solid color to draw upon
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Drawing Logic //
			// Draw blank game map to the screen
			worldMap.Draw(spriteBatch, camera, new List<Tileset>());
			
			base.Draw(gameTime); // Call MonoGame/XNA built-in Draw method
		}
	}
}
// END TacticsRPG