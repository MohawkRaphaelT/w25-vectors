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
        Vector2[] positions = [
            new Vector2(100, 200),
            new Vector2(300, 200),
            new Vector2(200, 75),
            ];
        float[] corneaRadii = [60, 30, 45];
        float[] irisRadii = [25, 20, 30];
        float[] pupilRadii = [15, 10, 20];
        Color[] irisColors = [
            new Color(128, 64, 0), // brown,
            new Color(32, 128, 48), // olive green,
            Color.Blue,
            ];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Eyeball Animation with Vectors");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            for (int i = 0; i < positions.Length; i++)
            {
                Vector2 position = positions[i];
                float corneaR = corneaRadii[i];
                float irisR = irisRadii[i];
                float pupilR = pupilRadii[i];
                Color color = irisColors[i];
                DrawEyeball(position, corneaR, irisR, pupilR, color);
            }
        }

        void DrawEyeball(Vector2 position, float corneaR, float irisR, float pupilR, Color color)
        {
            // Draw Cornea
            Draw.LineColor = Color.Black;
            Draw.LineSize = 1;
            Draw.FillColor = Color.White;
            Draw.Circle(position, corneaR);

            // Get direction from eye to mouse
            Vector2 vectorToMouse = Input.GetMousePosition() - position;
            Vector2 directionToMouse = Vector2.Normalize(vectorToMouse);
            float distanceToMouse = vectorToMouse.Length();

            // Calculate iris and pupil position
            Vector2 irisPupilPosition;
            if (distanceToMouse < (corneaR - irisR))
            {
                irisPupilPosition = Input.GetMousePosition();
            }
            else
            {
                irisPupilPosition = position + directionToMouse * (corneaR - irisR);
            }

            // Draw iris
            Draw.FillColor = color;
            Draw.Circle(irisPupilPosition, irisR);
            // Draw pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(irisPupilPosition, pupilR);
        }
    }

}
