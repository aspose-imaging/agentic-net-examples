// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp\\temp.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions { VectorRasterizationOptions = svgRasterOptions };
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                var pngSaveOptions = new PngOptions();
                raster.Save(outputPath, pngSaveOptions);
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
 * 1. When you need to convert a vector SVG logo to a raster PNG thumbnail with a subtle blur for web UI placeholders.
 * 2. When generating blurred background images from SVG assets for responsive design, you can rasterize and apply a Gaussian filter in C#.
 * 3. When preprocessing SVG diagrams before printing, applying a Gaussian blur helps soften edges and the code saves the result as a PNG file.
 * 4. When creating low‑resolution preview images of complex SVG illustrations, you can use Aspose.Imaging to rasterize and add a Gaussian blur for faster loading.
 * 5. When automating a batch workflow that adds a consistent blur effect to multiple SVG icons and outputs PNGs for mobile apps, this C# snippet handles the entire process.
 */
