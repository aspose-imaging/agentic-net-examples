// HOW-TO: How to Save BMP as Grayscale PSD with RLE Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/output.psd";

            // Validate input file existence
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
                // Configure PSD saving options
                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.CompressionMethod = CompressionMethod.RLE;
                    psdOptions.ColorMode = ColorModes.Grayscale;

                    // Attempt to save as PSD with error handling
                    try
                    {
                        image.Save(outputPath, psdOptions);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error saving PSD: {ex.Message}");
                    }
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
 * 1. When you need to convert a BMP image to a grayscale Photoshop PSD file with RLE compression while ensuring the output folder exists.
 * 2. When your application must verify that the source image file is present before attempting a format conversion to avoid runtime errors.
 * 3. When you want to log detailed error messages if saving the PSD fails, helping with troubleshooting in production environments.
 * 4. When you are building a batch processing tool that processes multiple BMP files and saves them as PSDs with consistent compression settings.
 * 5. When you require a robust C# solution that uses Aspose.Imaging to handle image loading, option configuration, and exception handling in a single workflow.
 */
