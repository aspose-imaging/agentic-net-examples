// HOW-TO: Apply Gaussian Blur to Scanned PNG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\scanned_input.png";
            string outputPath = @"C:\Images\scanned_blurred.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Create Gaussian blur options (kernel size = 5, sigma = 4.0)
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

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
 * 1. When you need to reduce noise in a scanned PNG before running OCR with Aspose.OCR in a C# application.
 * 2. When preprocessing scanned PDF pages exported as PNG to improve text extraction accuracy in a document management system.
 * 3. When preparing high‑resolution scanned receipts for automated data entry by applying a Gaussian blur filter using Aspose.Imaging in .NET.
 * 4. When cleaning up scanned forms with speckles or uneven lighting before converting them to searchable PDFs in a C# workflow.
 * 5. When batch‑processing archived scanned images to standardize blur levels for consistent OCR results across different file formats.
 */
