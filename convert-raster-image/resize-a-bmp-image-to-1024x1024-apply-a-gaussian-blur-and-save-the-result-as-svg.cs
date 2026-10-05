// HOW-TO: Resize BMP to 1024x1024, Apply Gaussian Blur and Export as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1024, 1024, ResizeType.NearestNeighbourResample);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                image.Filter(image.Bounds, blurOptions);

                SvgOptions svgOptions = new SvgOptions();
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
 * 1. When you need to generate a scalable SVG thumbnail from a high‑resolution BMP for responsive web design.
 * 2. When a desktop application must preprocess scanned BMP documents by resizing them to a uniform size and softening details before vector conversion.
 * 3. When an automated pipeline creates blurred background graphics from BMP assets for use in UI themes and requires SVG output for infinite scaling.
 * 4. When you want to convert legacy BMP icons into SVG format while applying a Gaussian blur to achieve a modern, softened appearance.
 * 5. When a reporting tool needs to embed blurred, resized BMP images as SVG illustrations to keep file size low and maintain quality across different screen resolutions.
 */
