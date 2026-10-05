// HOW-TO: Apply Gaussian Blur to JPEG While Preserving DPI Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\blurred.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                double originalHorizontal = raster.HorizontalResolution;
                double originalVertical = raster.VerticalResolution;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                raster.HorizontalResolution = originalHorizontal;
                raster.VerticalResolution = originalVertical;

                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to soften a high‑resolution JPEG for a web gallery but must keep the original DPI for accurate print scaling.
 * 2. When generating preview thumbnails of scanned documents where a blur reduces noise yet the DPI information must remain unchanged for downstream OCR tools.
 * 3. When applying a Gaussian blur to product photos in an e‑commerce pipeline while ensuring the image metadata stays intact for consistent catalog dimensions.
 * 4. When creating a blurred background effect for a mobile app UI and the image’s resolution metadata must be preserved for responsive layout calculations.
 * 5. When processing medical imaging JPEGs that require anonymization via blurring while retaining DPI data required for diagnostic measurements.
 */
