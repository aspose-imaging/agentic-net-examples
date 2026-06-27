using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
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

            // Temporary rasterized PNG path
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG to PNG conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized PNG to temporary file
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as RasterImage
            using (Image image = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply predefined blur filter using ConvolutionFilterOptions
                // Using a 5x5 box blur kernel
                var blurKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurKernel);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath);
            }

            // Optionally delete the temporary file
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
 * 1. When a developer needs to generate a blurred thumbnail of an SVG logo for a web gallery, they can use this code to rasterize the SVG to PNG and apply a 5x5 box blur filter.
 * 2. When creating PDF reports that embed blurred background images derived from vector graphics, this snippet lets you convert the SVG to a raster PNG and apply a convolution blur in C#.
 * 3. When preparing assets for a mobile app where SVG icons must be softened to reduce visual noise, the code demonstrates how to load the SVG, rasterize it, and apply a predefined blur filter before saving as PNG.
 * 4. When implementing a server‑side image‑processing service that accepts SVG uploads and returns blurred PNG previews, this example shows the end‑to‑end workflow using Aspose.Imaging’s ConvolutionFilterOptions.
 * 5. When automating batch processing of marketing banners that require a subtle blur effect on vector illustrations, the program illustrates how to loop through SVG files, rasterize them, and apply a 5x5 box blur filter in .NET.
 */