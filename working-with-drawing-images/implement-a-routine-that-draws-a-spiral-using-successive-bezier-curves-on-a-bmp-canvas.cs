using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\spiral.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a BMP image of size 800x800
        BmpOptions bmpOptions = new BmpOptions();
        using (Image image = Image.Create(bmpOptions, 800, 800))
        {
            // Initialize graphics object
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen for drawing the spiral
            Pen pen = new Pen(Color.Blue, 2);

            // Spiral parameters
            float centerX = 400f;
            float centerY = 400f;
            int segments = 100;                     // Number of Bezier segments
            float deltaAngle = (float)(Math.PI / 4); // 45 degrees per segment
            float deltaRadius = 5f;                  // Radius increase per segment

            // Starting point at the center
            float startX = centerX;
            float startY = centerY;
            float prevAngle = 0f;
            float prevRadius = 0f;

            for (int i = 0; i < segments; i++)
            {
                // Compute angle and radius for the current segment
                float angle = prevAngle + deltaAngle;
                float radius = prevRadius + deltaRadius;

                // End point of the Bezier curve
                float endX = centerX + radius * (float)Math.Cos(angle);
                float endY = centerY + radius * (float)Math.Sin(angle);

                // Approximate control points to create a smooth spiral
                float ctrl1X = centerX + (prevRadius + deltaRadius / 3f) * (float)Math.Cos(prevAngle + deltaAngle / 3f);
                float ctrl1Y = centerY + (prevRadius + deltaRadius / 3f) * (float)Math.Sin(prevAngle + deltaAngle / 3f);

                float ctrl2X = centerX + (prevRadius + 2f * deltaRadius / 3f) * (float)Math.Cos(prevAngle + 2f * deltaAngle / 3f);
                float ctrl2Y = centerY + (prevRadius + 2f * deltaRadius / 3f) * (float)Math.Sin(prevAngle + 2f * deltaAngle / 3f);

                // Draw the Bezier segment
                graphics.DrawBezier(pen,
                    startX, startY,
                    ctrl1X, ctrl1Y,
                    ctrl2X, ctrl2Y,
                    endX, endY);

                // Prepare for the next segment
                startX = endX;
                startY = endY;
                prevAngle = angle;
                prevRadius = radius;
            }

            // Save the resulting image
            image.Save(outputPath);
        }
    }
}