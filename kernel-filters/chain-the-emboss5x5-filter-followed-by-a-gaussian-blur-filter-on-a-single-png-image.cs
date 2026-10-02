// HOW-TO: Apply Emboss and Gaussian Blur Filters to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply Emboss5x5 filter
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                // Apply Gaussian blur filter
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.0)));

                // Save the result as PNG
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
 * 1. When you need to add an embossed 3‑D effect and then smooth a PNG image using Aspose.Imaging in C#.
 * 2. When creating UI icons that require a raised look with softened edges by applying Emboss5x5 and Gaussian blur filters.
 * 3. When preprocessing scanned PNG documents to emphasize texture and reduce noise before OCR in a .NET application.
 * 4. When generating stylized thumbnails for a web gallery where an emboss filter followed by a blur improves visual appeal.
 * 5. When building an automated .NET image pipeline that applies artistic emboss and blur effects to PNG assets before deployment.
 */
