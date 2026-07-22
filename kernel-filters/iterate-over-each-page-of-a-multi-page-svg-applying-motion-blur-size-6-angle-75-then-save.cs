// HOW-TO: Apply Motion Blur To Each Page Of A Multi‑Page SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded image is not a multipage SVG.");
                    return;
                }

                int pageCount = multipage.PageCount;

                for (int i = 0; i < pageCount; i++)
                {
                    // Rasterization options for SVG
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // PNG save options with rasterization and single-page export
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions,
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    // Render the current page to a raster image in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Apply motion blur (size 6, brightness 1.0, angle 75)
                            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(6, 1.0, 75.0));

                            // Save the processed page
                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            raster.Save(outputPath);
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
 * 1. When you need to add a consistent motion‑blur effect to every page of a multi‑page SVG before converting it to PNG thumbnails for a web gallery.
 * 2. When generating animated frames from a vector illustration where each SVG page represents a step and a blur must be applied to simulate movement.
 * 3. When preparing print‑ready assets from a multi‑page SVG and you want to apply a uniform 6‑pixel blur at 75° to all pages to meet a design specification.
 * 4. When automating a batch process that converts each page of a complex SVG diagram into PNG files with a motion‑blur filter for inclusion in a presentation.
 * 5. When building a C# service that receives multi‑page SVG uploads, applies a motion blur of size 6 at angle 75 to each page, and stores the resulting PNGs for downstream processing.
 */
