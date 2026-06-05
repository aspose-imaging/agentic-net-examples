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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access TIFF-specific methods
                TiffImage tiffImage = (TiffImage)image;

                // Apply Gaussian blur filter (radius: 5, sigma: 4.0)
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter (kernel size: 5, sigma: 4.0)
                tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to reduce noise in a high‑resolution scanned TIFF document, apply a Gaussian blur followed by a sharpen filter, and then deliver the result as a web‑friendly PNG.
 * 2. When a medical imaging application must preprocess TIFF X‑ray images by smoothing and enhancing edges before converting them to PNG for integration with a reporting system.
 * 3. When a digital archiving tool requires batch processing of TIFF photographs to improve clarity with blur‑then‑sharpen effects and store the output as lossless PNG files.
 * 4. When a GIS platform wants to clean up TIFF satellite tiles, apply a Gaussian blur to remove speckle, sharpen details, and export to PNG for fast map rendering.
 * 5. When an e‑commerce site processes product scans in TIFF format, uses Aspose.Imaging to blur background noise, sharpen product features, and save the final image as PNG for the storefront.
 */