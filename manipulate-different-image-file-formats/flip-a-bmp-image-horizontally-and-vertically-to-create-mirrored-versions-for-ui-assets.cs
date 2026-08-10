// HOW-TO: Flip BMP Image Horizontally and Vertically Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths
            string inputPath = "input.bmp";
            string outputDir = "output";
            string outputHorizontal = Path.Combine(outputDir, "horizontal.bmp");
            string outputVertical = Path.Combine(outputDir, "vertical.bmp");

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputHorizontal));
            Directory.CreateDirectory(Path.GetDirectoryName(outputVertical));

            // Create horizontal flipped image
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                image.Save(outputHorizontal, new BmpOptions());
            }

            // Create vertical flipped image
            using (Image image = Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                image.Save(outputVertical, new BmpOptions());
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
 * 1. When you need mirrored BMP icons for left‑to‑right UI layouts without manually editing each file.
 * 2. When generating flipped versions of game sprites to reuse the same artwork for opposite directions.
 * 3. When creating vertically mirrored background textures for seamless scrolling effects in a desktop application.
 * 4. When preparing both horizontal and vertical reflections of scanned BMP diagrams for documentation purposes.
 * 5. When automating batch processing of BMP assets to produce opposite‑facing images for responsive design.
 */
