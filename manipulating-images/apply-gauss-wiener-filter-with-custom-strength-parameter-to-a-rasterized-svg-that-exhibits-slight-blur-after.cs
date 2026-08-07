using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImg;

                        int radius = 5;
                        double sigma = 4.0;
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(radius, sigma));

                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert an SVG logo to a high‑resolution PNG for a website but wants to reduce the slight blur introduced during rasterization by applying a Gauss‑Wiener filter with custom radius and sigma values.
 * 2. When an automated build pipeline generates thumbnail previews from vector icons and must sharpen the images after rasterizing them to PNG using Aspose.Imaging in C#.
 * 3. When a desktop application imports user‑provided SVG diagrams, rasterizes them to bitmap format, and applies a custom‑strength Gauss‑Wiener filter to improve visual clarity before saving as PNG.
 * 4. When a batch‑processing script processes a folder of SVG assets, converts each to PNG, and uses the Gauss‑Wiener filter to compensate for anti‑aliasing artifacts caused by the rasterization step.
 * 5. When a reporting tool creates printable PNG charts from SVG templates and needs to enhance edge definition by tuning the Gauss‑Wiener filter’s radius and sigma parameters in a .NET environment.
 */