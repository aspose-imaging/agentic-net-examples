using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        double[,] kernel = ConvolutionFilter.Emboss3x3;
                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        var outPngOptions = new PngOptions();
                        raster.Save(outputPath, outPngOptions);
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
 * 1. When a developer needs to convert an SVG logo into a high‑contrast PNG thumbnail for a web gallery, they can apply a custom edge‑detection kernel with Aspose.Imaging to highlight the logo’s outlines.
 * 2. When an e‑learning platform wants to generate printable worksheets that emphasize diagram boundaries, they can rasterize SVG illustrations and run a ConvolutionFilter to produce clear edge‑enhanced PNG images.
 * 3. When a GIS application must overlay vector maps with stylized edge‑highlighted raster tiles, the code can load the SVG map, rasterize it, and apply the emboss/edge detection filter before saving as PNG.
 * 4. When a mobile app requires lightweight PNG assets with emphasized edges for low‑resolution screens, developers can use the ConvolutionFilter on SVG assets to create optimized edge‑detected images.
 * 5. When an automated testing pipeline validates visual quality of SVG icons by comparing edge‑detected PNG outputs, the code provides a reproducible way to rasterize and filter the icons using C# and Aspose.Imaging.
 */