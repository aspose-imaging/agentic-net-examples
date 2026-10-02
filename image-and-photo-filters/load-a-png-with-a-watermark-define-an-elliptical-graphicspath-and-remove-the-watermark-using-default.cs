// HOW-TO: Remove Elliptical Watermark From PNG Using ContentAwareFill In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                // Define an elliptical GraphicsPath (not used for removal but created as required)
                var graphicsPath = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
                graphicsPath.AddFigure(figure);

                // Define mask points approximating the ellipse
                var maskPoints = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(50, 50),
                    new Aspose.Imaging.Point(250, 50),
                    new Aspose.Imaging.Point(250, 150),
                    new Aspose.Imaging.Point(50, 150)
                };

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(maskPoints);
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);

                using (result)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    result.Save(outputPath, new PngOptions());
                }
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
 * 1. When you need to programmatically delete an elliptical logo or watermark from a PNG file in a .NET image‑processing workflow.
 * 2. When you want to generate a clean version of a scanned document that contains a semi‑transparent circular seal using Aspose.Imaging.
 * 3. When you are building a batch tool that removes watermarks from product photos before uploading them to an e‑commerce site.
 * 4. When you have to prepare images for machine‑learning training by stripping out embedded watermarks without manually editing each file.
 * 5. When you need to replace a protected watermark with the original background using the default ContentAwareFill algorithm in C#.
 */
