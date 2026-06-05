using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        double[,] kernel = new double[,]
                        {
                            { 1, 0, 1 },
                            { 0, 0, 0 },
                            { 1, 0, 1 }
                        };

                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        rasterImage.Save(outputPath);
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
 * 1. When a developer needs to convert an SVG logo to a PNG thumbnail and use Aspose.Imaging’s convolution filter in C# to highlight the logo’s corners for a UI preview.
 * 2. When an e‑commerce site automatically rasterizes SVG product illustrations to PNG and applies a custom corner‑isolating kernel to make the edges stand out in promotional emails.
 * 3. When a GIS application loads SVG map symbols, rasterizes them with Aspose.Imaging, and runs a corner‑detecting convolution filter to improve visual separation of marker edges on the final PNG map.
 * 4. When a game asset pipeline processes SVG icons, uses C# to rasterize them to PNG and applies a custom kernel that isolates corners, creating a stylized effect for in‑game UI elements.
 * 5. When a document automation system extracts SVG diagrams, converts them to PNG with Aspose.Imaging, and runs a corner‑isolation filter to aid OCR or subsequent image‑analysis steps.
 */