// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        float positionX = 0;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Move Over Time");
            Window.SetSize(400, 400);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            // Update position
            positionX += Time.DeltaTime * 100;
            if (positionX > Window.Width)
            {
                positionX = 0;
            }

            Draw.FillColor = Color.Red;
            Draw.Circle(positionX, 200, 50);
        }
    }

}
