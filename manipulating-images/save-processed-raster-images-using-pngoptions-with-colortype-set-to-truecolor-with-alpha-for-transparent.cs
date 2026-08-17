// HOW-TO: Save JPEG as PNG with Truecolor Alpha Transparency in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Images\sample.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image.
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with Truecolor with Alpha (supports transparency).
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the image as PNG using the configured options.
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime exception without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a JPEG photo to a PNG that retains transparent areas for web graphics.
 * 2. When generating thumbnails that require an alpha channel so they can be overlaid on different backgrounds.
 * 3. When preparing UI assets where truecolor PNGs with alpha are required for smooth gradients and effects.
 * 4. When processing scanned documents and saving them as lossless PNGs with transparency for later PDF composition.
 * 5. When exporting chart images from a reporting tool and need the PNG to preserve semi‑transparent elements.
 */
