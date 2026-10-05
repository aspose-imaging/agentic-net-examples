// HOW-TO: Apply Gaussian Blur and Custom Edge Detection to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempDir = "temp";
            string outputDir = "output";
            string tempPngPath = Path.Combine(tempDir, "temp.png");
            string outputPath = Path.Combine(outputDir, "output.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(tempDir);
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterizationOptions;
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load raster image and apply filters
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                // Predefined Gaussian blur filter
                var blurOptions = new GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Custom edge‑detection kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var edgeOptions = new ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, edgeOptions);

                // Save final image
                var finalPngOptions = new PngOptions();
                raster.Save(outputPath, finalPngOptions);
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
 * 1. When you need to smooth an SVG graphic and then highlight its outlines before converting it to a PNG for web thumbnails.
 * 2. When generating printable assets where a blurred background and sharp edge accent are required from vector illustrations.
 * 3. When preprocessing SVG icons for machine‑learning models that expect raster images with edge‑enhanced features.
 * 4. When creating custom map tiles that require a softened base layer and emphasized road edges using Aspose.Imaging in a .NET service.
 * 5. When automating a batch workflow that converts vector logos to PNGs with built‑in blur and edge‑detection filters for branding guidelines.
 */
