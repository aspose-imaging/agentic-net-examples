// HOW-TO: Convert SVG to PNG in C# with Aspose.Imaging and File Checks (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace AsposeImagingDemo
{
    // This program demonstrates a typical document conversion workflow using Aspose.Imaging.
    // It loads an SVG file, converts it to PNG, and saves the result.
    // The code follows the required safety rules:
    //   • Hard‑coded input and output paths.
    //   • Input file existence check without throwing.
    //   • Output directory creation unconditionally.
    //   • All logic wrapped in a try/catch that reports errors to the console.
    class Program
    {
        static void Main()
        {
            // Hard‑coded paths – adjust these values for your environment.
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the source file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                // Load the source document. Aspose.Imaging automatically detects the format.
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PNG save options (default settings are sufficient for most cases).
                    var pngOptions = new PngOptions();

                    // Save the image in the desired format.
                    image.Save(outputPath, pngOptions);
                }

                Console.WriteLine($"Conversion succeeded. Output saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                // Any unexpected error is reported without crashing the application.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically transform vector SVG graphics into raster PNG files for web thumbnails or UI assets in a .NET application.
 * 2. When your automation script must verify the source SVG exists before conversion to avoid runtime errors.
 * 3. When you want to ensure the destination folder is created automatically so the PNG can be saved without manual directory setup.
 * 4. When you require a simple try/catch block that logs conversion failures to the console instead of crashing the service.
 * 5. When you prefer default PNG options but still need explicit control over input and output paths in a C# console utility.
 */
