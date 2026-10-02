// HOW-TO: Rotate BMP Image By Arbitrary Angle With Transparent Background In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                float angle = 45f; // arbitrary rotation angle
                image.Rotate(angle, true, Color.Transparent);

                BmpOptions options = new BmpOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to display a BMP graphic at a custom orientation in a UI while keeping the surrounding area transparent.
 * 2. When generating thumbnails for a game asset pipeline that require rotated BMP sprites without a solid background.
 * 3. When processing scanned documents that must be tilted to correct alignment and the empty corners should remain invisible in the final image.
 * 4. When creating dynamic map overlays where BMP tiles are rotated based on user interaction and the background must stay transparent for layering.
 * 5. When automating batch image preparation for printing where each BMP file must be rotated by a specific angle and saved with a transparent fill to avoid unwanted borders.
 */
