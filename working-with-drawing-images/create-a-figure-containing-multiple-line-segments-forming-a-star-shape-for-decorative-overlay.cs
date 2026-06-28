using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\star_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image of size 500x500
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Define star shape points
                PointF[] starPoints = new PointF[]
                {
                    new PointF(250, 50),
                    new PointF(317, 200),
                    new PointF(475, 200),
                    new PointF(350, 300),
                    new PointF(400, 450),
                    new PointF(250, 375),
                    new PointF(100, 450),
                    new PointF(150, 300),
                    new PointF(25, 200),
                    new PointF(183, 200)
                };

                // Create a figure and add the star polygon shape
                Figure starFigure = new Figure();
                starFigure.AddShape(new PolygonShape(starPoints, true));

                // Create a graphics path and add the figure
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(starFigure);

                // Draw the star with a black pen of width 2
                graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 2), path);

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
 * 1. When a developer needs to programmatically add a decorative star watermark to a BMP image using Aspose.Imaging’s Graphics and PolygonShape classes for printable certificates or promotional flyers.
 * 2. When an application must generate a 500×500 star‑shaped badge overlay in C# for a game UI or achievement icon by creating a Figure and adding it to a GraphicsPath.
 * 3. When a reporting tool requires drawing a star highlight on a background image before exporting to PDF, leveraging Aspose.Imaging’s BmpOptions and Graphics.Clear methods.
 * 4. When a batch image‑processing script has to draw geometric star shapes onto multiple BMP files using Aspose.Imaging’s Figure, PolygonShape, and Graphics objects prior to sending them to a printing service.
 * 5. When a developer wants to prototype a star‑shaped logo or emblem in C# by using Aspose.Imaging’s Figure, GraphicsPath, and PolygonShape to create a reusable decorative overlay.
 */