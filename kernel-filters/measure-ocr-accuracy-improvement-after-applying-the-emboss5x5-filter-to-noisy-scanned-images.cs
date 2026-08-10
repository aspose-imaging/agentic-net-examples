// HOW-TO: How to Apply Emboss5x5 Filter to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

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

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage for filtering
                TiffImage tiffImage = (TiffImage)image;

                // Apply Emboss5x5 filter to the entire image
                tiffImage.Filter(tiffImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                // Save the filtered image (PNG format for OCR processing)
                tiffImage.Save(outputPath, new PngOptions());

                // Placeholder: Perform OCR on original and filtered images
                // string originalText = PerformOcr(inputPath);
                // string filteredText = PerformOcr(outputPath);
                // Compute and display OCR accuracy improvement here
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
 * 1. When you need to enhance noisy scanned TIFF documents with an emboss filter before running OCR in a C# application.
 * 2. When you want to convert multi‑page TIFF images to PNG after applying a convolution filter for better text extraction.
 * 3. When you must preprocess archival scanned images to improve character recognition accuracy using Aspose.Imaging’s Emboss5x5 filter.
 * 4. When you are building a batch processing pipeline that validates input files, applies image sharpening, and outputs OCR‑ready PNG files.
 * 5. When you require a simple C# example that demonstrates loading a TIFF, applying a convolution filter, and saving the result for downstream OCR analysis.
 */
