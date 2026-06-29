using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
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
            string rasterPath = "rasterized.png";
            string filteredPath = "filtered.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

            // Load SVG image and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(rasterPath, pngOptions);
            }

            // Load the rasterized PNG as RasterImage
            using (Image img = Image.Load(rasterPath))
            {
                RasterImage rasterImage = (RasterImage)img;

                // Define a valid 3x3 convolution kernel (sharpen)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                var convOptions = new ConvolutionFilterOptions(kernel);

                try
                {
                    // Apply convolution filter
                    rasterImage.Filter(rasterImage.Bounds, convOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Convolution filter error: {ex.Message}");
                }

                // Save the filtered image
                rasterImage.Save(filteredPath, new PngOptions());
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
 * 1. When a developer needs to convert scalable vector graphics (SVG) to raster PNG files and apply a sharpening convolution filter while safely handling invalid kernel errors in a C# .NET application.
 * 2. When building an automated image pipeline that rasterizes SVG logos to PNG thumbnails and logs any exceptions caused by malformed custom convolution kernels.
 * 3. When creating a batch processing tool that processes multiple SVG assets, rasterizes them, and applies edge‑enhancement filters, with try‑catch blocks to capture and record convolution filter failures.
 * 4. When integrating Aspose.Imaging into a web service that receives user‑uploaded SVGs, converts them to PNG, and applies custom image filters, ensuring that invalid kernel definitions are caught and logged for debugging.
 * 5. When developing a desktop utility that allows designers to preview filtered PNG versions of SVG illustrations and needs to gracefully handle and log errors from incorrect convolution matrix sizes.
 */