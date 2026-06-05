using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\star_output.tiff";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a blank TIFF image (500x500)
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize graphics object
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define star vertices
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

                // Build a closed figure from the star points
                var figure = new Figure { IsClosed = true };
                figure.AddShape(new PolygonShape(starPoints));

                // Create a GraphicsPath and add the figure
                var path = new GraphicsPath();
                path.AddFigure(figure);

                // Create a radial (path) gradient brush based on the same path
                var brush = new PathGradientBrush(path);
                brush.CenterColor = Color.Yellow;
                brush.SurroundColors = new Color[] { Color.Red };

                // Fill the star shape with the gradient brush
                graphics.FillPath(brush, path);

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
 * 1. When a developer needs to generate a printable promotional flyer with a star‑shaped badge that has a smooth yellow‑to‑transparent radial gradient and must be saved as a high‑resolution TIFF for professional printing.
 * 2. When an e‑commerce platform wants to overlay a glowing star watermark on product images, using a PathGradientBrush to create a subtle radial fade and storing the result in a lossless TIFF for catalog archives.
 * 3. When a scientific visualization tool requires drawing a highlighted star marker on a 500×500 raster canvas to emphasize data points, employing Aspose.Imaging’s GraphicsPath and radial gradient brush for crisp anti‑aliased rendering.
 * 4. When a game developer creates in‑game achievement icons programmatically, generating a star shape with a yellow center and orange rim using a PathGradientBrush and exporting it as a TIFF asset for further processing.
 * 5. When a reporting system automatically produces certification badges that include a star emblem with a radial color transition, using C# and Aspose.Imaging to draw the shape and save it as a TIFF file for inclusion in PDF reports.
 */