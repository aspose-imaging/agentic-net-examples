using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a GraphicsPath to hold the star figure
                GraphicsPath starPath = new GraphicsPath();

                // Define star points (5‑pointed star)
                const int pointsCount = 10;
                PointF[] starPoints = new PointF[pointsCount];
                float centerX = image.Width / 2f;
                float centerY = image.Height / 2f;
                float outerRadius = Math.Min(image.Width, image.Height) * 0.4f;
                float innerRadius = outerRadius * 0.5f;
                double angleStep = Math.PI / 5; // 36 degrees

                for (int i = 0; i < pointsCount; i++)
                {
                    double angle = i * angleStep - Math.PI / 2; // start at top
                    float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                    starPoints[i] = new PointF(
                        centerX + (float)(radius * Math.Cos(angle)),
                        centerY + (float)(radius * Math.Sin(angle))
                    );
                }

                // Build the figure with the star polygon
                Figure starFigure = new Figure();
                starFigure.IsClosed = true;
                starFigure.AddShape(new PolygonShape(starPoints));

                // Add the figure to the path
                starPath.AddFigure(starFigure);

                // Create a radial gradient brush based on the star path
                PathGradientBrush gradientBrush = new PathGradientBrush(starPath);
                gradientBrush.CenterColor = Color.Yellow;
                gradientBrush.SurroundColors = new Color[] { Color.Red };

                // Fill the star with the gradient brush
                graphics.FillPath(gradientBrush, starPath);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image
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
 * 1. When a developer needs to overlay a decorative 5‑pointed star with a smooth radial gradient onto a PNG logo for branding or watermarking purposes.
 * 2. When an application must generate custom badge icons by drawing a star shape and applying a radial gradient brush to create a glossy, three‑dimensional effect in C# using Aspose.Imaging.
 * 3. When a game UI requires dynamic generation of star‑shaped health or achievement symbols on the fly, and the code fills them with a radial gradient to simulate lighting.
 * 4. When a reporting tool wants to highlight key data points on a chart by programmatically adding a star marker with a radial gradient fill to a PNG export.
 * 5. When an e‑commerce platform needs to programmatically add a “featured‑product” star overlay with a radial gradient to product images before saving them as PNG files.
 */