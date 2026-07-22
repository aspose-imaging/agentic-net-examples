using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\filtered.png";
        string tempPath = "output\\temp.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImg = Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImg;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized image and save final output
            using (RasterImage rasterImg = (RasterImage)Image.Load(tempPath))
            {
                rasterImg.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert vector graphics in SVG format to a raster PNG for web display or thumbnail generation, this code loads the SVG, rasterizes it, and saves the result.
 * 2. When an automated build pipeline must generate PNG assets from SVG icons while ensuring a white background for consistency across platforms, the example demonstrates using Aspose.Imaging's SvgRasterizationOptions.
 * 3. When a .NET application has to batch‑process SVG files and store the rasterized images in a specific output folder, the code shows how to verify file existence, create directories, and handle errors gracefully.
 * 4. When a developer wants to embed a temporary rasterization step to apply further image‑processing filters (e.g., custom kernels) on a PNG before final output, this pattern of saving to a temp file and reloading as a RasterImage is useful.
 * 5. When troubleshooting image conversion issues, the example provides a clear way to isolate the rasterization stage by separating SVG loading from PNG saving, making debugging of Aspose.Imaging operations easier.
 */