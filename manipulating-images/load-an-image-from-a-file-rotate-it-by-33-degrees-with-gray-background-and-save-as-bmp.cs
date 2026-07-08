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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load, rotate, and save the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate 33 degrees, resize proportionally, gray background
                image.Rotate(33f, true, Color.Gray);
                // Save as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a desktop application needs to generate a rotated thumbnail of a user‑uploaded JPEG and store it as a BMP for legacy printing systems.
 * 2. When an automated batch job processes scanned documents, rotates each page by a specific angle to correct skew, fills empty corners with gray, and saves the result in BMP format for archival.
 * 3. When a game development tool imports texture assets, applies a 33‑degree rotation with a gray background to match a sprite sheet layout, and outputs BMP files for the engine’s texture pipeline.
 * 4. When a medical imaging workflow converts patient photos from JPEG to BMP after applying a precise rotation for alignment with diagnostic equipment, using C# and Aspose.Imaging.
 * 5. When a web service receives an image, needs to rotate it by a non‑standard angle, pad the background with gray, and return a BMP file compatible with older Windows applications.
 */