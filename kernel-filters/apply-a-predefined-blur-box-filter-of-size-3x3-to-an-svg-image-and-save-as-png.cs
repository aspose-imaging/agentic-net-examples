// HOW-TO: Apply 3x3 Box Blur to SVG and Convert to PNG in C# (Aspose.Imaging for .NET)
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
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                            { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                        };

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to soften vector graphics before generating raster thumbnails for a web gallery, you can blur the SVG and save it as a PNG.
 * 2. When a reporting tool requires blurred background images derived from SVG logos, this code rasterizes the SVG, applies a box blur, and outputs a PNG for PDF embedding.
 * 3. When creating privacy‑preserving previews of user‑uploaded SVG diagrams, you can blur the image and convert it to PNG to hide details while keeping the shape visible.
 * 4. When preparing assets for a game UI that needs a subtle glow effect, you can apply a 3×3 convolution blur to the SVG and export the result as a PNG sprite.
 * 5. When automating batch processing of SVG icons to generate low‑resolution, blurred PNG versions for mobile apps, this routine handles the conversion and filtering in C#.
 */
