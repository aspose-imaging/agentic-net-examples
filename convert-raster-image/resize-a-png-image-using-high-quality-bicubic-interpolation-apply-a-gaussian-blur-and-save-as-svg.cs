// HOW-TO: Resize PNG With Lanczos And Gaussian Blur Then Save As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                var blurOptions = new GaussianBlurFilterOptions(5, 2.0);
                image.Filter(image.Bounds, blurOptions);

                var svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, svgOptions);
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
 * 1. When creating high‑resolution web graphics, a developer can double the size of a PNG, apply a smooth blur, and export it as scalable SVG for responsive designs.
 * 2. When preparing icons for retina displays, the code lets you upscale a PNG with Lanczos interpolation, add a subtle Gaussian blur for anti‑aliasing, and save as SVG to keep file size low.
 * 3. When converting raster artwork into a vector‑compatible format, you can enlarge the image, soften edges with a Gaussian filter, and output an SVG that can be edited in vector editors.
 * 4. When generating blurred background images for UI overlays, the snippet resizes the source PNG, applies a Gaussian blur, and stores the result as an SVG that scales without pixelation.
 * 5. When automating a batch process that needs both higher resolution and a soft focus effect before vectorizing, this C# code resizes, blurs, and saves each PNG as an SVG for further processing.
 */
