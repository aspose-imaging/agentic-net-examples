// HOW-TO: Save BMP as Grayscale PSD Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

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
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    // Set color mode to Grayscale for monochrome output
                    ColorMode = ColorModes.Grayscale
                };

                // Save the image as PSD with the specified options
                image.Save(outputPath, psdOptions);
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
 * 1. When you need to convert a color BMP scan into a grayscale PSD for printing press workflows that require monochrome files.
 * 2. When an application must generate PSD assets from user‑uploaded images while ensuring the output uses a grayscale color mode to reduce file size.
 * 3. When preparing archival graphics, you may want to store original BMPs as PSDs with grayscale mode to preserve detail without color information.
 * 4. When building a batch‑processing tool that converts a folder of BMP files to PSD format for designers who work only with grayscale layers.
 * 5. When integrating Aspose.Imaging into a C# service that creates PSD mock‑ups from BMP logos and needs the result in monochrome for branding guidelines.
 */
