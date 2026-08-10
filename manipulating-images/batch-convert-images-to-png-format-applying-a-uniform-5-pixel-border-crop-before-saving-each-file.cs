// HOW-TO: Batch Convert Images to PNG with 5‑Pixel Border Crop in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input files
            string[] inputPaths = new[]
            {
                @"c:\input\image1.jpg",
                @"c:\input\image2.bmp",
                @"c:\input\image3.tif"
            };

            // Hardcoded output directory
            string outputDir = @"c:\output\";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Ensure the image is large enough for a 5‑pixel border crop
                    if (image.Width <= 10 || image.Height <= 10)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        continue;
                    }

                    // Define the crop rectangle (remove 5 pixels from each side)
                    var cropRect = new Rectangle(5, 5, image.Width - 10, image.Height - 10);

                    // Prepare PNG save options
                    var pngOptions = new PngOptions();

                    // Build output file path (same name, .png extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped area as PNG
                    image.Save(outputPath, pngOptions, cropRect);
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
 * 1. When you need to prepare a set of product photos for a web catalog by removing unwanted edges and saving them as lightweight PNG files.
 * 2. When an automated pipeline must trim a uniform border from scanned documents before archiving them in PNG format.
 * 3. When a game developer wants to batch‑process sprite sheets, cropping a 5‑pixel margin and converting them to PNG for consistent texture handling.
 * 4. When a reporting tool generates charts as JPEG or BMP and you must batch‑convert them to PNG while removing a decorative frame.
 * 5. When a migration script moves legacy image assets to a new system, requiring a small border crop and format change to PNG for compatibility.
 */
