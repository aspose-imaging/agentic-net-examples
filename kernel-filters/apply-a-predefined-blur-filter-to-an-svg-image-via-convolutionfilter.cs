// HOW-TO: Apply Blur Convolution Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary rasterized PNG path
            string tempPngPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid SVG image.");
                    return;
                }

                // Set up rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Save rasterized PNG to temporary file
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = rasterImageContainer as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Failed to load raster image for filtering.");
                    return;
                }

                // Create a predefined blur filter (box blur with size 5)
                ConvolutionFilterOptions blurOptions = new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(5));

                // Apply the blur filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to generate a blurred thumbnail of an SVG logo for a web page.
 * 2. When you want to preprocess vector graphics by applying a blur effect before converting them to raster PNG for email newsletters.
 * 3. When creating background images with soft edges from SVG icons for a mobile app UI.
 * 4. When automating batch processing of SVG assets to produce blurred PNG files for print layouts.
 * 5. When integrating image processing into a C# service that applies a convolution blur to user‑uploaded SVG files for privacy masking.
 */
