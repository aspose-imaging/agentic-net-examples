// HOW-TO: Rasterize SVG, Apply Sharpen Filter, and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage
                SvgImage svgImage = (SvgImage)image;

                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load raster image from memory
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply custom convolution kernel (sharpen example)
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        // Create a new SVG canvas
                        SvgGraphics2D graphics = new SvgGraphics2D(svgImage.Width, svgImage.Height, 96);

                        // Draw the filtered raster onto the SVG canvas
                        graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                        // Finalize SVG image
                        using (SvgImage finalSvg = graphics.EndRecording())
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            finalSvg.Save(outputPath);
                        }
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
 * 1. When you need to enhance an SVG logo with a sharpening effect while keeping the file editable as SVG.
 * 2. When you want to programmatically apply a custom convolution kernel to vector graphics for web‑optimized images.
 * 3. When you must process SVG assets in a .NET service, rasterize them for filtering, then return the result as SVG for downstream design tools.
 * 4. When you are building an automated pipeline that improves the visual clarity of SVG icons before embedding them in a mobile app.
 * 5. When you require in‑memory image processing of SVG files without writing temporary PNG files to disk.
 */
