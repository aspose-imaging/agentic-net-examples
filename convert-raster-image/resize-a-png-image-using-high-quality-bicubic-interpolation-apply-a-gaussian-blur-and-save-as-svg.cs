// HOW-TO: Resize PNG with Bicubic Interpolation, Apply Gaussian Blur, Save as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = raster.Width * 2;
                int newHeight = raster.Height * 2;

                raster.Resize(newWidth, newHeight, ResizeType.CubicConvolution);
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to upscale a low‑resolution PNG for high‑quality printing while smoothing edges with a Gaussian blur before converting it to a scalable SVG.
 * 2. When generating web‑ready vector graphics from raster icons, you want to double their size using bicubic scaling and add a subtle blur for a modern look.
 * 3. When preparing assets for a responsive UI, you may resize PNG assets, apply a blur effect for a soft‑focus background, and store them as SVG to keep file size low.
 * 4. When automating a batch process that converts scanned PNG diagrams into larger, blurred SVG illustrations for inclusion in documentation.
 * 5. When creating stylized thumbnails where the original PNG is enlarged, blurred, and saved as an SVG to retain crisp vector outlines at any display size.
 */
