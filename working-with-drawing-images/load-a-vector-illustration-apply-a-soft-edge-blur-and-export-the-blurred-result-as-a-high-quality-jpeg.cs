// HOW-TO: Apply Gaussian Blur to SVG and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.jpg";
            string tempPngPath = "temp.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG, apply Gaussian blur, and save as high-quality JPEG
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;

                // Apply soft-edge Gaussian blur (radius 5, sigma 2.0)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0));

                var jpegOptions = new JpegOptions
                {
                    Quality = 95,
                    // High-quality settings can be adjusted as needed
                };

                raster.Save(outputPath, jpegOptions);
            }

            // Optionally delete temporary PNG file
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
 * 1. When a web application needs to convert scalable SVG icons into blurred JPEG banners for faster loading on browsers.
 * 2. When an e‑commerce platform wants to generate soft‑edge background images from vector product illustrations for promotional emails.
 * 3. When a reporting tool requires high‑quality JPEG snapshots of vector diagrams with a subtle blur effect for PDF export.
 * 4. When a mobile app creates stylized preview thumbnails from SVG assets by rasterizing, applying Gaussian blur, and compressing to JPEG.
 * 5. When a digital signage system preprocesses vector artwork into blurred JPEGs to achieve a smooth visual transition on large displays.
 */
