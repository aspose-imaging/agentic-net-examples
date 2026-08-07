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
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Rotate 120 degrees, resize proportionally, fill background with blue
                image.Rotate(120f, true, Aspose.Imaging.Color.Blue);

                // Prepare BMP save options with bound file source
                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the rotated image
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
 * 1. When a developer needs to rotate a BMP image by a non‑right‑angle (e.g., 120°) and fill the uncovered corners with a specific background color such as blue for a game asset pipeline.
 * 2. When an application must process legacy BMP files, apply a custom rotation while preserving the original pixel format, and ensure the output file is saved with the same BMP format.
 * 3. When generating printable marketing material that requires rotating scanned BMP graphics and using a solid background color to avoid transparent gaps in the final PDF.
 * 4. When building a C# desktop utility that batch‑processes BMP icons, rotates each icon by 120 degrees, and uses a uniform background to maintain visual consistency across different screen resolutions.
 * 5. When integrating Aspose.Imaging into an automated workflow that reads BMP images from a folder, rotates them for correct orientation, and saves them with a custom background color to meet branding guidelines.
 */