using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source fileSource = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = fileSource };

            // Canvas size
            int width = 800;
            int height = 600;

            // Create BMP canvas
            using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Create a pen with rounded line caps
                Pen pen = new Pen(Color.Blue, 4);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // Draw smooth Bezier curve
                graphics.DrawBezier(pen,
                    new Point(100, 500),
                    new Point(200, 100),
                    new Point(600, 100),
                    new Point(700, 500));

                // Draw smooth cardinal curve
                Point[] curvePoints = new Point[]
                {
                    new Point(100, 300),
                    new Point(250, 150),
                    new Point(550, 150),
                    new Point(700, 300)
                };
                graphics.DrawCurve(pen, curvePoints);

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to generate a BMP file with smooth, anti‑aliased curves for a printable diagram, they can use Aspose.Imaging for .NET to draw Bezier and cardinal curves with a Pen that has rounded line caps.
 * 2. When creating custom UI assets such as toolbar icons or button backgrounds in a Windows desktop application, the code shows how to programmatically render high‑quality curved lines on a BMP canvas using C# graphics primitives.
 * 3. When automating the production of engineering schematics that require precise curve rendering, the example demonstrates how to save the result directly to a file system path with BmpOptions and a FileCreateSource.
 * 4. When building a server‑side service that converts vector path data into raster BMP images for legacy systems, the Pen with rounded caps ensures the generated curves appear smooth and professional.
 * 5. When testing image‑processing pipelines that need a known BMP image containing both Bezier and cardinal curves for validation, this snippet provides a reproducible way to create the test image using Aspose.Imaging for .NET.
 */