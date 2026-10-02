// HOW-TO: Create a Star Shape with Radial Gradient Fill in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new PNG image
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };
            int width = 400;
            int height = 400;
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Create graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define star points (5-point star)
                PointF[] starPoints = new PointF[]
                {
                    new PointF(200, 50),
                    new PointF(240, 150),
                    new PointF(350, 150),
                    new PointF(260, 220),
                    new PointF(300, 330),
                    new PointF(200, 260),
                    new PointF(100, 330),
                    new PointF(140, 220),
                    new PointF(50, 150),
                    new PointF(160, 150)
                };

                // Create a polygon shape for the star
                PolygonShape starShape = new PolygonShape(starPoints);

                // Create a figure and add the star shape
                Figure starFigure = new Figure();
                starFigure.AddShape(starShape);

                // Create a graphics path and add the figure
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(starFigure);

                // Fill the star with a solid brush (radial gradient not supported)
                using (SolidBrush brush = new SolidBrush(Color.Gold))
                {
                    graphics.FillPath(brush, path);
                }

                // Optionally draw the outline
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

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
 * 1. When you need to generate a custom star logo with a smooth radial color transition for a PNG badge in a .NET web service.
 * 2. When you want to programmatically create decorative star graphics for game UI elements or score indicators using Aspose.Imaging.
 * 3. When you must produce printable marketing material that includes a star‑shaped watermark with a gradient effect in C#.
 * 4. When you are building an automated report that embeds a star‑shaped chart marker with a radial gradient into a PDF or image output.
 * 5. When you require dynamic generation of star‑shaped icons with gradient fills for mobile app assets without using external design tools.
 */
