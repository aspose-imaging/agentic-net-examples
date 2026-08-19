// HOW-TO: Convert CDR to JPG with Exception Handling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.jpg";

        // Global exception handling
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

            // Load the CDR file and convert to JPG
            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception conversionEx)
            {
                // Log any conversion-specific exceptions
                Console.Error.WriteLine($"Conversion error: {conversionEx.Message}");
                // Re-throw to be caught by outer handler if needed
                throw;
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑convert CorelDRAW (.cdr) files to JPEG images in a .NET service while safely handling missing files and conversion errors.
 * 2. When an automated build or CI pipeline must generate preview thumbnails from CDR designs and log any runtime exceptions for troubleshooting.
 * 3. When a desktop application allows users to upload CDR artwork and you must save it as a high‑quality JPG, ensuring the output folder is created if absent.
 * 4. When integrating Aspose.Imaging into a server‑side API that receives CDR uploads and returns JPG responses, you need robust error handling to return meaningful error messages.
 * 5. When migrating legacy design assets to web‑friendly formats and you want a C# script that logs conversion failures without crashing the entire process.
 */
