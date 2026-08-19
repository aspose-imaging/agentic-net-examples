// HOW-TO: How To Set PNG Compression Level In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\source.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with a balanced compression level (0-9)
                var pngOptions = new PngOptions
                {
                    // Progressive loading (optional)
                    Progressive = true,
                    // Use truecolor with alpha for full color fidelity
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    // Set compression level to 5 (moderate compression, good balance)
                    CompressionLevel = 5
                };

                // Save the image as PNG with the specified options
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
 * 1. When you need to convert high‑resolution JPEG photos to PNG for web delivery while keeping file size reasonable, you can adjust the CompressionLevel in PngOptions.
 * 2. When generating thumbnails that require transparent backgrounds, setting ColorType to TruecolorWithAlpha ensures full color fidelity with alpha channel support.
 * 3. When building a batch‑processing tool that must create progressive PNGs for faster progressive rendering in browsers, you enable the Progressive flag.
 * 4. When deploying an application that stores user‑uploaded images on limited storage, balancing CompressionLevel (e.g., 5) helps reduce disk usage without noticeable quality loss.
 * 5. When automating image conversion in a C# service and you must guarantee the output directory exists before saving, the code creates the folder and saves the PNG with the configured options.
 */
