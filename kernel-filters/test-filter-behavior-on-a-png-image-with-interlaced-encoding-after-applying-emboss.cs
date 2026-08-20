// HOW-TO: Apply Emboss Filter to PNG and Save as Interlaced in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output_emboss_interlaced.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply emboss filter (3x3 kernel)
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Configure PNG save options with interlaced (progressive) encoding
                PngOptions options = new PngOptions
                {
                    Progressive = true
                };

                // Save the processed image
                raster.Save(outputPath, options);
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
 * 1. When you need to enhance a PNG thumbnail with a 3 × 3 emboss effect before delivering it as a progressive image for faster web preview.
 * 2. When your application must apply a convolution‑based emboss filter to a raster image and output an interlaced PNG to reduce perceived loading time on slow connections.
 * 3. When you are building a C# batch‑processing tool that automatically adds depth to product photos and saves them with progressive PNG encoding for better SEO.
 * 4. When you want to test Aspose.Imaging’s filter pipeline by applying an emboss kernel and verifying that the resulting PNG uses interlaced compression.
 * 5. When you are converting user‑uploaded PNGs into stylized, interlaced assets for a mobile app that displays images incrementally as they download.
 */
