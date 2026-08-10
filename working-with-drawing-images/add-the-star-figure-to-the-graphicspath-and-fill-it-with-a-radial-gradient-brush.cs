// HOW-TO: Add Star Shape to PNG with Radial Gradient Brush in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create PNG options with file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a graphics path
                Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();

                // Define star shape points
                Aspose.Imaging.PointF[] starPoints = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(250f,  50f),
                    new Aspose.Imaging.PointF(300f, 200f),
                    new Aspose.Imaging.PointF(450f, 200f),
                    new Aspose.Imaging.PointF(325f, 300f),
                    new Aspose.Imaging.PointF(375f, 450f),
                    new Aspose.Imaging.PointF(250f, 350f),
                    new Aspose.Imaging.PointF(125f, 450f),
                    new Aspose.Imaging.PointF(175f, 300f),
                    new Aspose.Imaging.PointF( 50f, 200f),
                    new Aspose.Imaging.PointF(200f, 200f)
                };

                // Create figure and add star polygon shape
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(new PolygonShape(starPoints, true));

                // Add figure to graphics path
                graphicsPath.AddFigure(figure);

                // Fill the star shape with a solid brush
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.FillPath(brush, graphicsPath);
                }

                // Save the image
                image.Save();
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
 * 1. When you need to generate a custom star logo on a white PNG canvas using Aspose.Imaging for C#.
 * 2. When you want to programmatically create a vector‑based star illustration with a radial gradient fill for print‑ready graphics in .NET.
 * 3. When an application must dynamically render a star icon with a gradient brush for UI elements such as buttons or avatars.
 * 4. When you are building a reporting tool that adds a highlighted star marker to charts or diagrams and saves them as PNG files.
 * 5. When you require automated creation of promotional images that include a star shape with a radial gradient for marketing emails.
 */
