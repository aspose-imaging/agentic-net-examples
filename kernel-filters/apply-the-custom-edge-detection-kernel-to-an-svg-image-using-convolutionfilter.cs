// HOW-TO: Apply Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);
                        rasterImage.Save(outputPath, pngOptions);
                    }
                }
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
 * 1. When you need to highlight the edges of an SVG illustration before converting it to a PNG thumbnail for a web gallery.
 * 2. When you want to generate a print‑ready PNG from an SVG logo with a custom convolution filter that emphasizes outlines.
 * 3. When you are preprocessing SVG diagrams with edge detection to improve OCR accuracy after rasterizing them to PNG.
 * 4. When you are creating a C# batch utility that applies a sharpening/edge‑detection filter to many SVG files and saves the results as PNG images.
 * 5. When you require server‑side image processing in a .NET application to detect and accentuate outlines in SVG icons for dynamic UI theming.
 */
