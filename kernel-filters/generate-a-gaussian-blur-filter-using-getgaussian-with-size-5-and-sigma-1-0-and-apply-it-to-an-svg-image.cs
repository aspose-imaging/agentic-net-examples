// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string tempPngPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            // Load SVG and rasterize to temporary PNG
            using (Aspose.Imaging.Image svgImg = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgImage = (SvgImage)svgImg;
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG, apply Gaussian blur, and save final output
            using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(tempPngPath))
            {
                var raster = (Aspose.Imaging.RasterImage)rasterImg;
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                var finalPngOptions = new PngOptions();
                raster.Save(outputPath, finalPngOptions);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { }
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
 * 1. When you need to convert vector graphics to raster images with a soft blur for web thumbnails.
 * 2. When you want to preprocess SVG logos before embedding them in a PDF with a subtle blur effect.
 * 3. When generating blurred background images from SVG icons for UI overlays in a .NET application.
 * 4. When creating low‑resolution preview PNGs of SVG diagrams with Gaussian smoothing to reduce aliasing.
 * 5. When automating batch processing of SVG assets to produce blurred PNG assets for mobile app splash screens.
 */
