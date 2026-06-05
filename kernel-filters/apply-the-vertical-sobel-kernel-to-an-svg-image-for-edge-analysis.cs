using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\edge_output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)svgImg;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;
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
 * 1. When a developer needs to convert an SVG illustration to a high‑resolution PNG thumbnail using Aspose.Imaging in C# for web or mobile UI rendering.
 * 2. When a .NET application must rasterize vector graphics from an SVG file into a PNG image to perform subsequent edge detection or computer‑vision analysis.
 * 3. When an automated build pipeline requires batch processing of SVG assets into PNG format with a white background for inclusion in PDF reports or email newsletters.
 * 4. When a graphics service needs to load an SVG, rasterize it with exact page dimensions, and save the result as a PNG file to ensure consistent visual quality across different browsers.
 * 5. When a developer wants to programmatically verify the existence of an SVG file, create the output directory, and safely export the vector image to PNG while handling I/O errors in a C# application.
 */