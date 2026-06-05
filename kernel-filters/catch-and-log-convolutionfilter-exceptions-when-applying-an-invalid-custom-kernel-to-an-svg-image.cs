using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

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

            // Load the SVG image
            using (Image svgImg = Image.Load(inputPath))
            {
                // Cast to SvgImage to satisfy using directive
                SvgImage svg = (SvgImage)svgImg;

                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    svgImg.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        // Create an invalid convolution kernel (non‑square)
                        double[,] invalidKernel = new double[2, 3];

                        // Attempt to apply convolution filter and catch any exception
                        try
                        {
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(invalidKernel);
                            raster.Filter(raster.Bounds, filterOptions);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"Convolution filter error: {ex.Message}");
                        }

                        // Save the (possibly unchanged) raster image
                        raster.Save(outputPath, pngOptions);
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
 * 1. When a web application allows users to upload SVG graphics and apply custom convolution kernels for artistic effects, developers need to catch and log exceptions to prevent crashes from invalid non‑square kernels.
 * 2. When an automated batch job converts SVG logos to PNG thumbnails and applies edge‑detection filters, exception handling ensures that malformed kernel definitions are recorded without halting the entire process.
 * 3. When a desktop tool lets designers experiment with custom blur or emboss kernels on vector illustrations, logging convolution filter errors helps diagnose why a particular kernel configuration fails.
 * 4. When a CI/CD pipeline validates image processing scripts that rasterize SVG files and apply security‑oriented sharpening filters, catching exceptions provides clear feedback on invalid kernel parameters.
 * 5. When an IoT device generates SVG diagrams and applies real‑time noise‑reduction filters before transmitting PNG images, exception logging guarantees that any incorrect kernel size is captured for remote debugging.
 */