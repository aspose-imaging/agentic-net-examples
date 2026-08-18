// HOW-TO: Rotate BMP Image by Arbitrary Degrees with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output_rotated.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate by arbitrary angle (e.g., 45 degrees) with proportional resize
                // and transparent background for empty areas
                float angle = 45f; // change as needed
                image.Rotate(angle, true, Color.Transparent);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rotated image preserving transparency (Bitfields compression)
                var bmpOptions = new BmpOptions
                {
                    // Bitfields compression retains alpha channel
                    Compression = BitmapCompression.Bitfields
                };
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to display a rotated bitmap in a UI without black corners, you can rotate the BMP and fill empty space with transparency.
 * 2. When generating game sprites that require arbitrary orientation, this code lets you rotate BMP assets while preserving alpha.
 * 3. When preparing images for a PDF or web page where the background must be invisible, you can rotate the BMP and keep a transparent background.
 * 4. When processing scanned documents that need to be aligned at non‑standard angles, the routine rotates the BMP and avoids unwanted background color.
 * 5. When converting legacy BMP graphics for use in modern applications that support alpha channels, this method adds transparency after rotation.
 */
