// HOW-TO: Crop Top Left Quadrant of JPEG and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;
                image.Crop(0, halfWidth, 0, halfHeight);
                var options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to extract the upper‑left quarter of a raster photo and embed it in a vector‑based report.
 * 2. When generating lightweight SVG thumbnails from large JPEG images for responsive web pages.
 * 3. When converting a specific region of a scanned document into scalable SVG for printing at any size.
 * 4. When creating cut‑out graphics from a bitmap to be used in vector editing tools like Adobe Illustrator.
 * 5. When automating batch processing to crop and vectorize image sections for a GIS mapping application.
 */
