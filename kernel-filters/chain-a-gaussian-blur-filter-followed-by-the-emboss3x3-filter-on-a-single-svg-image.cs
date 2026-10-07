// HOW-TO: Apply Gaussian Blur Followed by Emboss Filter to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = image as Aspose.Imaging.FileFormats.Svg.SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Failed to load SVG image.");
                    return;
                }

                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(ms))
                    {
                        Aspose.Imaging.RasterImage rasterImage = rasterImg as Aspose.Imaging.RasterImage;
                        if (rasterImage == null)
                        {
                            Console.Error.WriteLine("Failed to rasterize SVG.");
                            return;
                        }

                        var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                        rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

                        var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                        var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                        rasterImage.Filter(rasterImage.Bounds, embossOptions);

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
 * 1. When you need to create a soft‑focused, embossed version of a vector logo for a website banner.
 * 2. When generating stylized icons where the original SVG must be rasterized to PNG with a blur and emboss effect for a mobile app.
 * 3. When preprocessing SVG illustrations for print materials, adding a subtle blur before embossing to enhance depth perception.
 * 4. When building an automated pipeline that converts SVG assets to PNG thumbnails with artistic effects for an e‑commerce catalog.
 * 5. When implementing a custom image filter in a C# desktop application that applies sequential Gaussian blur and emboss filters to user‑uploaded SVG files.
 */
