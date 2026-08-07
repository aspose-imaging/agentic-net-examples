using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

            // Temporary rasterized PNG path
            string tempRasterPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

            // Load SVG and rasterize to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempRasterPath, pngOptions);
            }

            // Load rasterized image, apply Gaussian blur, and save result
            using (Image rasterImg = Image.Load(tempRasterPath))
            {
                var raster = (RasterImage)rasterImg;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));
                raster.Save(outputPath);
            }

            // Optional: clean up temporary file
            // File.Delete(tempRasterPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to add a soft focus effect to vector logos before embedding them in a web page, they can rasterize the SVG and apply a Gaussian blur with size 5 and sigma 1.0 using Aspose.Imaging for .NET.
 * 2. When generating thumbnail previews of SVG diagrams that require a subtle blur to reduce visual noise, the code can convert the SVG to PNG and apply the Gaussian blur filter.
 * 3. When preparing print‑ready assets where vector illustrations must be slightly softened to match a design style, the developer can use this routine to rasterize the SVG and apply a Gaussian blur.
 * 4. When building an automated image pipeline that processes user‑uploaded SVG icons and adds a blur effect for UI hover states, the example shows how to load, rasterize, blur, and save the result in C#.
 * 5. When creating a batch job that converts a collection of SVG files to blurred PNG sprites for a game engine, the code demonstrates the necessary steps with Aspose.Imaging’s GaussianBlurFilterOptions.
 */