using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\spiral.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 800;

            // Create a BMP image
            var bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the spiral
                var pen = new Pen(Color.Blue, 2);

                // Spiral parameters
                int turns = 5;                     // Number of full rotations
                float radiusStep = 20f;            // Increment of radius per segment
                float angleStep = (float)(Math.PI / 4); // 45 degrees per segment
                float centerX = width / 2f;
                float centerY = height / 2f;

                // Starting point of the first segment
                float angle = 0f;
                float radius = radiusStep;
                float x0 = centerX + radius * (float)Math.Cos(angle);
                float y0 = centerY + radius * (float)Math.Sin(angle);

                // Draw successive Bezier curves to form a spiral
                for (int i = 0; i < turns * 8; i++) // 8 segments per turn
                {
                    // Compute end point of the current segment
                    angle += angleStep;
                    radius += radiusStep;
                    float x3 = centerX + radius * (float)Math.Cos(angle);
                    float y3 = centerY + radius * (float)Math.Sin(angle);

                    // Approximate control points for a smooth curve
                    float cpAngle = angle - angleStep / 2f;
                    float cpRadius = radius - radiusStep / 2f;
                    float x1 = centerX + cpRadius * (float)Math.Cos(cpAngle);
                    float y1 = centerY + cpRadius * (float)Math.Sin(cpAngle);
                    float x2 = x1; // Using symmetric control points for simplicity
                    float y2 = y1;

                    // Draw the Bezier segment
                    graphics.DrawBezier(pen,
                        new PointF(x0, y0),
                        new PointF(x1, y1),
                        new PointF(x2, y2),
                        new PointF(x3, y3));

                    // Prepare for the next segment
                    x0 = x3;
                    y0 = y3;
                }

                // Save the resulting image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a high‑resolution BMP file with a mathematically accurate spiral drawn using successive Bezier curves for scientific visualizations or educational diagrams.
 * 2. When an application must create a custom background texture in C# by programmatically rendering a spiral pattern with Aspose.Imaging graphics and a blue Pen for a Windows desktop UI.
 * 3. When a reporting solution requires embedding a dynamically drawn spiral logo into BMP images that will later be inserted into PDF or Word documents via Aspose.Imaging.
 * 4. When a game developer wants to pre‑render a spiral path as a bitmap to use as a collision mask or sprite animation frame in a 2D game engine.
 * 5. When an automation script has to produce a printable BMP illustration of a spiral for promotional material, CNC plotting, or laser‑cutting designs.
 */