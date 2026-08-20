// HOW-TO: Convert TGA Background Image to Lossless PNG with Color Profile in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\background.tga";
            string outputPath = @"C:\Images\background.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Prepare PNG options to keep metadata (color profile)
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Save as lossless PNG
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
 * 1. When you need to replace a TGA texture used as a game background with a PNG that retains the original color accuracy.
 * 2. When preparing assets for a web application that requires lossless PNG files but the source images are stored in TGA format.
 * 3. When migrating legacy graphics from a design pipeline to a modern .NET system while preserving embedded ICC profiles.
 * 4. When automating a batch process that converts background images to PNG to reduce file size without sacrificing quality.
 * 5. When ensuring that a background image’s color profile is kept intact during format conversion for accurate printing or display.
 */
