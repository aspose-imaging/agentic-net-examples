using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImage = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImage;

                        var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);

                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath);
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
 * 1. When creating a web‑app that converts brand SVG icons to high‑contrast PNG thumbnails, a developer can use this code to emboss the lines for sharper definition while keeping the original colors intact.
 * 2. When generating printable assets from vector UI symbols, applying the Emboss5x5 filter after rasterizing the SVG ensures the output PNG has enhanced edge detail without modifying the icon’s palette.
 * 3. When building a desktop tool that previews SVG icons as PNGs with a subtle 3‑D effect, the convolution emboss filter can be applied to improve line visibility on light backgrounds.
 * 4. When preparing SVG‑based button graphics for a mobile game, developers can rasterize the SVG to PNG and run the Emboss5x5 filter to make the outlines pop on low‑resolution screens.
 * 5. When automating a batch process that converts a library of stylized SVG logos to PNG for email signatures, the code’s emboss filter adds depth to the strokes while preserving the original color scheme.
 */