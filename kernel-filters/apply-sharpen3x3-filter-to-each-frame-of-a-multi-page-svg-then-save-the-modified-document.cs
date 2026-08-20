// HOW-TO: Sharpen Each Page of Multi‑Page SVG and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.tif";

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
                if (!(image is IMultipageImage multipage))
                {
                    Console.Error.WriteLine("The loaded image is not a multipage vector image.");
                    return;
                }

                List<RasterImage> frames = new List<RasterImage>();

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        RasterImage raster = (RasterImage)Image.Load(ms);
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                        frames.Add(raster);
                    }
                }

                using (Image result = Image.Create(frames.ToArray(), true))
                {
                    result.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }

                foreach (var frame in frames)
                {
                    frame.Dispose();
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
 * 1. When you need to enhance the visual sharpness of every layer in a multi‑page SVG before converting it to a high‑resolution TIFF for printing.
 * 2. When an application must batch‑process vector diagrams, applying a 3×3 sharpen filter to each page and exporting them as a single multipage TIFF for archival.
 * 3. When you want to programmatically improve the clarity of SVG icons embedded in a document and store the result as a TIFF for compatibility with legacy systems.
 * 4. When generating thumbnails of each SVG page with increased edge definition and compiling them into a TIFF slideshow using C# and Aspose.Imaging.
 * 5. When converting a multi‑page SVG chart into a TIFF while automatically applying a sharpen filter to ensure details remain crisp after rasterization.
 */
