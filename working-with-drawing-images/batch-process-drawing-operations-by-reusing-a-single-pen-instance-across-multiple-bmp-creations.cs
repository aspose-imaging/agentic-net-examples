// HOW-TO: Reuse a Single Pen to Draw Rectangles in Multiple BMP Files with C# (Aspose.Imaging for .NET)
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
            string outputDir = "OutputImages";
            string[] outputFiles = { "image1.bmp", "image2.bmp", "image3.bmp" };
            Directory.CreateDirectory(outputDir);

            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);

            foreach (var fileName in outputFiles)
            {
                string outputPath = Path.Combine(outputDir, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions options = new BmpOptions();
                options.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(options, 200, 200))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(20, 20, 160, 160));
                    image.Save();
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
 * 1. When you need to generate a series of thumbnail BMP images that all share the same border style without creating a new Pen for each file.
 * 2. When automating the creation of report charts where each chart image is a BMP with identical rectangle outlines for consistent visual formatting.
 * 3. When processing a large set of scanned documents and you want to overlay a blue rectangle on each BMP to highlight a region of interest efficiently.
 * 4. When building a game asset pipeline that requires multiple BMP sprites with the same rectangular frame, reusing a single Pen reduces memory overhead.
 * 5. When developing a batch image conversion tool that adds a uniform border to many BMP files, using one Pen instance speeds up the drawing loop.
 */
