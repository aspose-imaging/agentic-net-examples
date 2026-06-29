using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\star_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image of size 500x500
            var pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics object
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define points for a 5‑pointed star
                PointF[] starPoints = new PointF[]
                {
                    new PointF(250f, 50f),
                    new PointF(280f, 180f),
                    new PointF(400f, 180f),
                    new PointF(300f, 250f),
                    new PointF(340f, 380f),
                    new PointF(250f, 300f),
                    new PointF(160f, 380f),
                    new PointF(200f, 250f),
                    new PointF(100f, 180f),
                    new PointF(220f, 180f)
                };

                // Create a closed figure containing the star polygon
                var figure = new Figure { IsClosed = true };
                figure.AddShape(new PolygonShape(starPoints));

                // Build a graphics path from the figure
                var path = new GraphicsPath();
                path.AddFigure(figure);

                // Create a radial gradient brush based on the path
                var brush = new PathGradientBrush(path)
                {
                    CenterColor = Color.Yellow,
                    SurroundColors = new Color[] { Color.Red }
                };

                // Fill the star with the gradient brush
                graphics.FillPath(brush, path);

                // Save the image
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
 * 1. When creating a custom badge or logo for a mobile app, a developer can use this code to draw a star shape and fill it with a radial gradient to give a glossy, eye‑catching effect in a PNG file.
 * 2. When generating printable certificates or awards, the code can render a star emblem with a yellow‑to‑red gradient that scales to 500 × 500 pixels and can be saved as a high‑resolution PNG for inclusion in PDF documents.
 * 3. When building an online game’s achievement icons, a developer can programmatically produce star graphics with a radial gradient brush, ensuring consistent colors and vector‑based shapes across all platforms.
 * 4. When automating the creation of promotional email banners, the snippet can be used to add a star illustration with a smooth gradient background, then export the result as a PNG that loads quickly in webmail clients.
 * 5. When developing a data‑visualization dashboard that highlights top‑ranked items, the code can generate a star marker with a radial gradient to overlay on charts, using Aspose.Imaging’s GraphicsPath and PathGradientBrush for precise rendering.
 */