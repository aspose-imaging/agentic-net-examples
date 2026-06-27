using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for temporary and final output files
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply blur box filter, and save final PNG
            using (Image img = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)img;
                var blurOptions = new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(3));
                raster.Filter(raster.Bounds, blurOptions);
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
 * 1. When a web developer needs to generate a low‑resolution preview PNG of a complex SVG logo with a subtle 3×3 blur to improve loading speed on mobile devices.
 * 2. When a desktop application must convert user‑uploaded SVG diagrams to PNG thumbnails and apply a uniform blur box filter to hide proprietary details before sharing.
 * 3. When an e‑learning platform automatically rasterizes SVG illustrations to PNG assets and adds a 3×3 blur to create a consistent background effect across all course materials.
 * 4. When a reporting tool processes SVG charts, rasterizes them to PNG, and applies a convolution blur to soften sharp edges for better visual integration in PDF reports.
 * 5. When a batch‑processing script in C# uses Aspose.Imaging to convert a folder of SVG icons to blurred PNG icons for use as placeholders during asynchronous UI loading.
 */