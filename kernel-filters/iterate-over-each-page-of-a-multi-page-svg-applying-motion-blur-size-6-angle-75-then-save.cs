// HOW-TO: Apply Motion Blur to Every SVG Page and Export PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outPath = Path.Combine(outputDir, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = image.Size };
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    image.Save(outPath, pngOptions);

                    using (RasterImage raster = (RasterImage)Image.Load(outPath))
                    {
                        raster.Filter(raster.Bounds, new MotionWienerFilterOptions(6, 1.0, 75.0));
                        raster.Save(outPath);
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
 * 1. When you need to generate blurred preview images for each layer of a multi‑page SVG diagram in a C# application.
 * 2. When creating a series of PNG assets with consistent motion‑blur effects for an animation storyboard extracted from an SVG file.
 * 3. When processing vector graphics for a web gallery and want each page rendered as a PNG with a 75‑degree motion blur for visual emphasis.
 * 4. When automating batch conversion of multi‑page SVG documents to PNG while applying a specific blur filter to improve readability in reports.
 * 5. When developing a C# tool that extracts individual pages from a complex SVG and adds a motion‑blur effect before saving them for use in presentations.
 */
