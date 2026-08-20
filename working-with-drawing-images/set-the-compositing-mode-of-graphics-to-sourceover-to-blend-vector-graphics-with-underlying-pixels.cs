// HOW-TO: How To Set Graphics Compositing Mode To SourceOver In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Source src = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions() { Source = src };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to overlay a transparent logo onto an existing PNG image while preserving the background colors.
 * 2. When generating dynamic charts that combine vector shapes with a photo background in a web application.
 * 3. When creating watermarked product images by compositing semi‑transparent text over a base picture.
 * 4. When building a thumbnail generator that draws vector icons on top of uploaded user photos.
 * 5. When implementing a PDF‑to‑PNG conversion that adds annotation graphics without erasing the original raster content.
 */
