// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            string tempPath = Path.Combine(Path.GetTempPath(), "tempRaster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600,
                    BackgroundColor = Color.White
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(tempPath, pngOptions);
            }

            // Load raster image and apply Gaussian blur kernel
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                double[,] customKernel = new double[,]
                {
                    { 0.0625, 0.125,  0.0625 },
                    { 0.125,  0.25,   0.125 },
                    { 0.0625, 0.125,  0.0625 }
                };

                ConvolutionFilterOptions convOptions = new ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, convOptions);

                PngOptions outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
            }

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to soften vector graphics before embedding them in a web page, you can rasterize an SVG, apply a Gaussian blur with Aspose.Imaging, and output a PNG for faster loading.
 * 2. When generating thumbnail previews of SVG icons with a subtle blur effect for UI hover states, this code converts the SVG to a raster image, blurs it, and saves the result as PNG.
 * 3. When preparing print‑ready assets that require a smooth blur on vector artwork, you can use the convolution filter to apply a Gaussian kernel to the rasterized SVG and export a high‑quality PNG.
 * 4. When creating stylized map overlays where the original SVG layers need a soft focus, the example shows how to rasterize, blur, and save the image using C# and Aspose.Imaging.
 * 5. When automating batch processing of SVG files to produce blurred PNG versions for marketing materials, this snippet demonstrates the end‑to‑end workflow with custom kernel convolution.
 */
