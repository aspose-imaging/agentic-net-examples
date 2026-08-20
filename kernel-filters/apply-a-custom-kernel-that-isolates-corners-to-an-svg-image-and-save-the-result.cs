// HOW-TO: Apply Corner Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                    rasterOptions.PageSize = image.Size;

                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image for filtering
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Custom kernel to isolate corners (edge detection)
                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save filtered result
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
 * 1. When you need to highlight the edges of vector graphics by converting an SVG to a raster PNG with a corner‑detecting convolution filter.
 * 2. When generating thumbnails that emphasize object outlines from SVG icons for UI previews using Aspose.Imaging in C#.
 * 3. When preprocessing SVG artwork for computer‑vision pipelines that require edge‑enhanced PNG inputs.
 * 4. When creating print‑ready assets where the corners of a logo must be accentuated before exporting to PNG.
 * 5. When building a web service that receives SVG files, applies custom kernel filtering to detect corners, and returns the filtered PNG to clients.
 */
