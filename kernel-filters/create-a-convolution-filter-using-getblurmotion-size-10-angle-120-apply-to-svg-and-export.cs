// HOW-TO: Apply Motion Blur Filter to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.svg";
            string tempPath = "Output/temp.png";
            string outputPath = "Output/filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    }
                };
                svgImage.Save(tempPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(10, 120)));
                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
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
 * 1. When you need to add a directional motion‑blur effect to a vector logo stored as SVG before publishing it as a raster PNG for web use.
 * 2. When an automated graphics pipeline must convert SVG illustrations to PNG thumbnails with a consistent blur applied for a stylized preview.
 * 3. When a desktop application generates reports that embed blurred SVG diagrams, requiring rasterization and filter processing in C#.
 * 4. When you want to preprocess SVG assets with a 10‑pixel, 120‑degree motion blur to simulate speed in a game UI and save the result as PNG.
 * 5. When a batch script processes a folder of SVG icons, applying the same convolution filter to each and exporting the filtered images for mobile app assets.
 */
