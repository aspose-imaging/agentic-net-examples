using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter (size 5) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Apply sharpen filter (kernel size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a C# application needs to clean up noisy PNG scans of printed forms by applying a median filter and then enhance the text edges with a sharpen filter using Aspose.Imaging.
 * 2. When a developer is preparing product photos for an e‑commerce website, removing grain with a median filter before sharpening details to improve visual appeal.
 * 3. When an automated document processing pipeline must reduce speckle noise in scanned PDFs (converted to raster images) and accentuate borders for better OCR accuracy.
 * 4. When a desktop utility written in .NET processes batches of JPEG screenshots, first smoothing color artifacts and then applying edge enhancement to make UI elements clearer.
 * 5. When a medical imaging tool needs to denoise grayscale X‑ray images and subsequently highlight bone edges for diagnostic review, using Aspose.Imaging’s MedianFilterOptions and SharpenFilterOptions.
 */