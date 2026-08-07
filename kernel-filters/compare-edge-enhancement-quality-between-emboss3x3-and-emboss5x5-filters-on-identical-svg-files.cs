using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input SVG path
            string inputPath = @"C:\Temp\input.svg";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output paths for the two filtered images
            string outputPath3x3 = @"C:\Temp\output_emboss3x3.png";
            string outputPath5x5 = @"C:\Temp\output_emboss5x5.png";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3x3));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5x5));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize the SVG to a raster image (default size)
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply 3x3 Emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the result of the 3x3 filter
                    rasterImage.Save(outputPath3x3);
                }
            }

            // Reload the original SVG for the second filter (to avoid cumulative effects)
            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply 5x5 Emboss filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

                    // Save the result of the 5x5 filter
                    rasterImage.Save(outputPath5x5);
                }
            }

            Console.WriteLine("Filtering completed. Results saved to:");
            Console.WriteLine(outputPath3x3);
            Console.WriteLine(outputPath5x5);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to evaluate which emboss filter (Emboss3x3 or Emboss5x5) preserves fine line details better for converting SVG icons to high‑contrast PNG thumbnails using Aspose.Imaging for .NET.
 * 2. When a UI designer wants to compare edge‑enhancement results on vector‑based logos after rasterizing them to PNG to decide the optimal filter for a web‑ready asset pipeline.
 * 3. When a GIS application processes SVG map overlays and must choose the most suitable convolution filter to highlight terrain contours without introducing artifacts.
 * 4. When an e‑learning platform generates embossed diagrams from SVG illustrations and needs to test both 3×3 and 5×5 kernels to ensure readability on low‑resolution screens.
 * 5. When a quality‑assurance engineer automates regression testing of Aspose.Imaging’s ConvolutionFilterOptions to verify that the Emboss5x5 filter produces smoother shading than Emboss3x3 on identical SVG inputs.
 */