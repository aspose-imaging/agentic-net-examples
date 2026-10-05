// HOW-TO: Resize Image to 1200x1200 Apply Median Filter and Export as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1200, 1200);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

                var svgOptions = new SvgOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When you need to create a noise‑reduced, 1200 px square SVG thumbnail from a high‑resolution JPEG for web display.
 * 2. When preparing product photos for responsive design that require a fixed square size and vector format for scalability.
 * 3. When converting scanned documents into clean SVG graphics for printing or annotation after applying a median filter to remove speckles.
 * 4. When automating batch processing of user‑uploaded images to standardize dimensions, denoise them, and store the results as SVG for low‑bandwidth delivery.
 * 5. When integrating image preprocessing into a C# application that must output vector graphics compatible with CAD or illustration tools.
 */
