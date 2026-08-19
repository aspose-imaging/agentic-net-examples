// HOW-TO: Apply Median Filter to OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input.otg";
        string outputPath = @"C:\output.png";

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

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG options with OTG rasterization settings
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Rasterize OTG to a memory stream (PNG format)
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    otgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image (now a RasterImage)
                    using (Image rasterImageBase = Image.Load(rasterStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageBase;

                        // Apply median filter with size 5 to the whole image
                        rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                        // Save the filtered image as PNG
                        rasterImage.Save(outputPath);
                    }
                }
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
 * 1. When you need to reduce noise in a vector OTG file before exporting it as a high‑quality PNG for web display.
 * 2. When converting CAD‑style OTG drawings to raster PNGs and want to smooth edges with a median filter to improve visual clarity.
 * 3. When generating thumbnails from OTG images for a gallery and require a quick noise‑removal step to keep the thumbnails clean.
 * 4. When processing scanned OTG documents that contain speckles and you must apply a median filter before saving them as PNG for archival.
 * 5. When integrating Aspose.Imaging into a C# batch job that converts multiple OTG files to PNG while automatically denoising each image.
 */
