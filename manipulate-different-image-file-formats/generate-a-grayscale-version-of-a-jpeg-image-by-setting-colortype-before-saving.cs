// HOW-TO: Create Grayscale JPEG From Color Image Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_grayscale.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options to produce a grayscale image
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set the color mode to Grayscale
                    ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: set quality (1-100)
                    Quality = 100
                };

                // Save the image with the specified options
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to convert color photos to grayscale JPEGs for printing on monochrome printers.
 * 2. When preparing image assets for a machine‑learning model that requires single‑channel input.
 * 3. When reducing visual complexity of product images for faster web page loading while keeping JPEG format.
 * 4. When archiving scanned documents as grayscale JPEGs to save storage space without changing file type.
 * 5. When generating grayscale thumbnails for a gallery application that only supports JPEG output.
 */
