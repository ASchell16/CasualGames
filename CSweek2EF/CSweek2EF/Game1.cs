using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CSweek2EF
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteFont SFont;
        SpriteBatch SBatch;

        DatabaseContext context = new DatabaseContext();
        List<Player> players = new List<Player>();
        
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            players = context.Players.ToList();
           
            //players = players.OrderBy(p => p.userName).ToList(); 
            //players = players.OrderByDescending(p => p.highScore).ToList();



            base.Initialize();
        }
       
        protected override void LoadContent()
        {
            SBatch = new SpriteBatch(GraphicsDevice);

            SFont = Content.Load<SpriteFont>("SFont");

        }
        
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            List<Player> topThree = players.Take(3).ToList();


            SBatch.Begin();
            for (int y = 0; y < players.Count; y++) {

                float height = SFont.MeasureString(players[y].userName).Y;
                float width = SFont.MeasureString(players[y].userName).X;

                SBatch.DrawString(SFont, players[y].userName, 
                                  new Vector2(5, y * height ), 
                                  Color.White);

                SBatch.DrawString(SFont, " Scored",
                                  new Vector2(50, y * height),
                                  Color.White);

                SBatch.DrawString(SFont, players[y].highScore,
                                  new Vector2(150, y * height),
                                  Color.White);


            }
            SBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
