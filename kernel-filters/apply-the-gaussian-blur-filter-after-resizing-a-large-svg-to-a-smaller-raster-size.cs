using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string resizedPath = @"C:\Images\resized.png";
            string outputPath = @"C:\Images\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load SVG, rasterize to a smaller PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                // Cast to SvgImage to access SVG-specific members
                SvgImage svg = (SvgImage)svgImage;

                // Set rasterization options with scaling (e.g., 50% size)
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svg.Size,
                    ScaleX = 0.5f,
                    ScaleY = 0.5f,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                // Save rasterized image to intermediate PNG file
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                svg.Save(resizedPath, pngOptions);
            }

            // Load the rasterized PNG, apply Gaussian blur, and save final result
            using (Image rasterImage = Image.Load(resizedPath))
            {
                // Cast to RasterImage to use filtering
                RasterImage raster = (RasterImage)rasterImage;

                // Apply Gaussian blur with kernel size 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save blurred image
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to generate a low‑resolution thumbnail of a complex SVG for a mobile app and wants a smooth, softened appearance, they can resize the SVG to a smaller PNG and apply a Gaussian blur filter.
 * 2. When generating responsive web graphics, a developer may rasterize a large SVG to a smaller PNG for faster loading and then use Gaussian blur to produce a subtle background blur effect behind overlay text.
 * 3. When preparing print‑ready assets, a designer can downscale a vector logo to a raster image and apply Gaussian blur to create a soft‑edge watermark that doesn’t distract from the main content.
 * 4. When building a photo‑editing tool that supports vector import, the code can resize the SVG to a preview size and add Gaussian blur to simulate depth‑of‑field before the user applies further edits.
 * 5. When creating UI placeholders in a desktop application, a developer can convert a detailed SVG icon to a small PNG and blur it to indicate a loading state without exposing the full‑resolution graphic.
 */