// HOW-TO: Apply Gaussian Blur Followed by Emboss Filter to SVG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size=5, sigma=4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Emboss3x3 filter using the built‑in kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
 * 1. When you need to convert a vector SVG logo into a stylized PNG thumbnail with a soft blur and embossed edge effect for web previews.
 * 2. When generating product catalog images where the original SVG artwork must be softened and given a 3‑D embossed look before saving as PNG.
 * 3. When creating UI icons that require a subtle Gaussian blur followed by an emboss to match a material design aesthetic, using Aspose.Imaging in C#.
 * 4. When preprocessing SVG diagrams for print layouts, applying blur to reduce visual noise and emboss to enhance line depth before rasterizing to PNG.
 * 5. When building an automated pipeline that transforms user‑uploaded SVG files into PNGs with a combined blur‑and‑emboss filter for consistent branding across platforms.
 */
