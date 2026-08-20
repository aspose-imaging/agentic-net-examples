// HOW-TO: Apply Gaussian Blur to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                tiffImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to soften scanned documents stored as TIFF before converting them to PNG for web display.
 * 2. When a batch process must reduce image detail in high‑resolution TIFF photos by applying a Gaussian blur and output them as PNG thumbnails.
 * 3. When preparing medical imaging TIFF files for patient portals, you may blur sensitive details and deliver the result in PNG format.
 * 4. When integrating legacy TIFF assets into a modern C# application that requires PNG images with a uniform blur effect for UI consistency.
 * 5. When automating a workflow that converts archived TIFF maps into blurred PNGs to protect copyrighted information while keeping them viewable.
 */
