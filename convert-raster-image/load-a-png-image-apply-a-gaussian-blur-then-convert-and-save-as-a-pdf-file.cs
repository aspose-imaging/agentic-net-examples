// HOW-TO: Apply Gaussian Blur to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\sample.png";
            string outputPath = "C:\\temp\\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)pngImage;

                // Apply Gaussian blur (radius: 5, sigma: 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PDF
                rasterImage.Save(outputPath, new PdfOptions());
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
 * 1. When you need to blur a PNG logo before embedding it in a PDF report to protect trademark visibility.
 * 2. When generating PDF catalogs from product images and want a soft focus effect on each PNG thumbnail.
 * 3. When preprocessing scanned PNG documents with a Gaussian blur to reduce noise before converting them to searchable PDFs.
 * 4. When creating PDF brochures that require a subtle background blur on PNG graphics for a professional design look.
 * 5. When automating a workflow that converts PNG screenshots into PDF manuals while applying a blur to hide sensitive screen details.
 */
