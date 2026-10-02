// HOW-TO: Apply Diagonal Edge Convolution to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "tempRaster.png");

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };
                svgImage.Save(tempPath, pngOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                {
                    double[,] kernel = new double[,]
                    {
                        { -1, 0, 1 },
                        { 0, 0, 0 },
                        { 1, 0, -1 }
                    };

                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                    raster.Save(outputPath, new PngOptions());
                }

                try { File.Delete(tempPath); } catch { }
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
 * 1. When you need to convert a vector SVG logo into a raster PNG while highlighting diagonal edges for a stylized web banner.
 * 2. When you want to preprocess SVG illustrations with a custom convolution kernel before embedding them in a PDF report.
 * 3. When you must generate PNG thumbnails of SVG diagrams that emphasize diagonal lines for better visual contrast in a UI gallery.
 * 4. When you are building an automated pipeline that applies edge‑enhancement to SVG assets and stores the results as PNG files on a server.
 * 5. When you require a C# solution to rasterize SVG files, apply a custom filter for edge detection, and save the processed images for machine‑learning training data.
 */
