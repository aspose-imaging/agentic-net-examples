// HOW-TO: Apply 7x7 Gaussian Blur Soft Focus to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output_softfocus.jpg";

        // Ensure any runtime exception is reported cleanly
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

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)jpegImage;

                // Apply a Gaussian blur with a 7x7 kernel (size = 7, sigma = 1.0)
                // This provides a soft‑focus effect while keeping overall brightness neutral.
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(7, 1.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When you need to create a subtle soft‑focus effect on product photos stored as JPEGs before uploading them to an e‑commerce site.
 * 2. When you want to reduce image detail while keeping overall brightness neutral for a portrait retouching workflow in a C# application.
 * 3. When you are building an automated batch processor that applies a 7×7 Gaussian blur to scanned documents saved as JPEG to improve readability.
 * 4. When you need to generate a background‑blurred thumbnail from a high‑resolution JPEG for a gallery preview in a .NET web app.
 * 5. When you are preparing images for a machine‑learning dataset and require a consistent blur filter to augment training data without altering exposure.
 */
