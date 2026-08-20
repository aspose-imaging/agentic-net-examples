// HOW-TO: Create 24bpp BMP Image With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set up BMP options with 24bpp RGB format
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = source
            };

            // Create a new image with the specified options
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Save the image (bound to the source, so no path needed)
                image.Save();
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
 * 1. When you need to generate a blank 24‑bit BMP file programmatically for a reporting system that requires a specific pixel format.
 * 2. When you must create a bitmap canvas, fill it with a solid color, and save it directly to disk without using intermediate streams.
 * 3. When an application has to produce thumbnails or placeholders in BMP format for legacy devices that only support 24bpp RGB images.
 * 4. When you want to automate the creation of custom‑sized images for batch processing, such as generating test patterns for image‑processing pipelines.
 * 5. When you are integrating Aspose.Imaging into a C# service that dynamically creates graphics for print‑ready documents that require BMP with exact color depth.
 */
