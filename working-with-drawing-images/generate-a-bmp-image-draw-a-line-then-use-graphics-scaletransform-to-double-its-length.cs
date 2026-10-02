// HOW-TO: Generate BMP Image and Double Line Length with ScaleTransform in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 200;
            int height = 100;

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 1);
                graphics.DrawLine(pen, new Point(10, 40), new Point(190, 40));

                graphics.ScaleTransform(2.0f, 1.0f);
                // Optional: draw another line to demonstrate scaling
                // graphics.DrawLine(pen, new Point(10, 60), new Point(190, 60));

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
 * 1. When you need to programmatically create a BMP file and draw simple graphics such as lines for reports or diagrams.
 * 2. When you want to apply a horizontal scaling transformation to extend the length of drawn objects without recalculating coordinates.
 * 3. When generating placeholder images for UI testing where the line length must be doubled to simulate different screen resolutions.
 * 4. When exporting technical schematics to BMP format and need to adjust line dimensions dynamically using Aspose.Imaging.
 * 5. When automating batch creation of scaled line drawings for printing where the original coordinates are fixed but the output size varies.
 */
