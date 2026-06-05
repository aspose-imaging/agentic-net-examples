using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.jpg";
            string outputPath = @"C:\Images\output.psd";

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
 * 1. When a developer needs to generate print‑ready black‑and‑white artwork from a JPEG and must deliver it as a PSD file with a grayscale color mode for accurate monochrome reproduction.
 * 2. When converting scanned documents to PSD format for archival, setting ColorMode to Grayscale reduces file size and ensures the saved file contains only luminance data.
 * 3. When building a web service that creates PSD mockups of product photos in grayscale for marketing campaigns, the code guarantees the output uses the correct PSD color mode.
 * 4. When automating batch processing of color images to create grayscale PSD layers for a digital painting workflow, the developer uses this snippet to enforce the grayscale mode during save.
 * 5. When integrating Aspose.Imaging into a C# desktop application that exports user‑edited photos as PSD files for further editing in Photoshop, setting ColorMode to Grayscale provides a clean monochrome starting point.
 */