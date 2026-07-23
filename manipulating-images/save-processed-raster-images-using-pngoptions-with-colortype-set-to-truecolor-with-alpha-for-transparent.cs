using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input\sample.jpg";
        string outputPath = @"output\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with Truecolor with Alpha
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to convert user‑uploaded JPEG photos to PNG files that preserve semi‑transparent overlays, a developer can use this code to load the JPEG, set PngOptions.ColorType to TruecolorWithAlpha, and save the result with an alpha channel.
 * 2. When generating product catalog thumbnails that require a transparent background for seamless integration into different UI themes, a C# developer can employ the Aspose.Imaging PNG save options with Truecolor with Alpha to ensure the PNG retains full color depth and transparency.
 * 3. When processing scanned documents that contain watermark graphics and need to be exported as lossless PNGs with transparent backgrounds for PDF composition, the code demonstrates how to load the raster image and save it with TruecolorWithAlpha using Aspose.Imaging.
 * 4. When building a desktop tool that batch‑converts legacy JPEG assets to PNG for use in game development, preserving the original colors and adding an alpha channel for sprite masking, the developer can apply the shown PngOptions configuration.
 * 5. When creating an automated email system that embeds images with transparent backgrounds into HTML emails, a developer can convert source images to PNG with Truecolor with Alpha to maintain visual quality and transparency across email clients.
 */