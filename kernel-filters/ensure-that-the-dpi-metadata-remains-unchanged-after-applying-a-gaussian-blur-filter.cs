// HOW-TO: Apply Gaussian Blur to JPEG in C# While Keeping Original DPI (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

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
                // Cast to RasterImage to access pixel operations
                RasterImage raster = (RasterImage)image;

                // Preserve original DPI (resolution)
                double originalHorizontalDpi = raster.HorizontalResolution;
                double originalVerticalDpi = raster.VerticalResolution;

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Restore original DPI after processing
                raster.SetResolution(originalHorizontalDpi, originalVerticalDpi);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When you need to soften a high‑resolution JPEG for a web gallery but must retain its original DPI for printing later.
 * 2. When a desktop application must automatically blur scanned documents to protect sensitive information while preserving the scan’s resolution metadata.
 * 3. When generating thumbnail previews of medical images where the blur is used for visual effect but the DPI must stay unchanged for compliance.
 * 4. When batch‑processing product photos to add a subtle blur for aesthetic purposes without altering the images’ embedded resolution data.
 * 5. When integrating an image‑editing feature into a C# reporting tool that applies Gaussian blur to charts yet keeps the DPI intact for accurate PDF export.
 */
