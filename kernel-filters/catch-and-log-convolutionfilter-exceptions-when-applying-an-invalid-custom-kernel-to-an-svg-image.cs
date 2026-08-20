// HOW-TO: Handle ConvolutionFilter Exception for Invalid Kernel on SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string tempPngPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure directories exist for temporary and final output files
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG to PNG conversion
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // PNG save options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a temporary PNG file
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                // Create an invalid custom kernel (2x2 matrix, which is not allowed)
                double[,] invalidKernel = new double[2, 2]
                {
                    { 1, 0 },
                    { 0, 1 }
                };

                // Initialize ConvolutionFilterOptions with the invalid kernel
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(invalidKernel);

                // Attempt to apply the filter and catch any exceptions
                try
                {
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);
                }
                catch (Exception filterEx)
                {
                    Console.Error.WriteLine($"Convolution filter error: {filterEx.Message}");
                }

                // Save the (potentially unfiltered) image to the final output path
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to apply a custom convolution filter to a rasterized SVG and must catch errors caused by unsupported kernel sizes.
 * 2. When converting vector SVG files to PNG and wants to log detailed exceptions if the filter matrix is invalid.
 * 3. When building an automated image‑processing workflow that processes SVG images and requires graceful handling of incorrect filter parameters.
 * 4. When debugging image filter configurations in a C# application and needs clear exception information for non‑conforming kernel dimensions.
 * 5. When creating a web service that accepts SVG uploads, applies convolution filters, and must return meaningful error messages for malformed kernels.
 */
