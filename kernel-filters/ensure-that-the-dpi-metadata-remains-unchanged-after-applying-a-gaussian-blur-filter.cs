using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\sample.GaussianBlur.png";

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
                // Cast to RasterImage to access filtering and resolution APIs
                RasterImage raster = (RasterImage)image;

                // Preserve original DPI (resolution)
                double originalHorizontalDpi = raster.HorizontalResolution;
                double originalVerticalDpi = raster.VerticalResolution;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Restore original DPI after filtering
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
 * 1. When a developer needs to apply a Gaussian blur to a high‑resolution PNG while keeping the original DPI for accurate printing.
 * 2. When an application must process scanned documents (e.g., PDFs converted to PNG) with a blur filter but preserve the metadata required for OCR scaling.
 * 3. When a web service generates blurred thumbnails from user‑uploaded images and must retain the source image’s resolution information for downstream workflows.
 * 4. When a batch‑processing tool uses Aspose.Imaging in C# to smooth medical images without altering the pixel‑per‑inch settings needed for diagnostic analysis.
 * 5. When a desktop utility needs to enhance photos with a Gaussian blur effect while ensuring the saved file maintains the same horizontal and vertical DPI for consistent display on different devices.
 */