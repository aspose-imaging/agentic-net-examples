// HOW-TO: Apply Gauss Wiener Filter to Rasterized SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\vector.svg";
            string outputPath = "Output\\filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions();
                        raster.Filter(raster.Bounds, filterOptions);
                        var outOptions = new PngOptions();
                        raster.Save(outputPath, outOptions);
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
 * 1. When converting SVG logos to PNG thumbnails for a web app, you can use this code to rasterize the vector and automatically reduce conversion blur with a Gauss‑Wiener filter.
 * 2. When preparing print‑ready assets from vector illustrations, the filter helps sharpen the rasterized image before saving it as high‑quality PNG.
 * 3. When building an automated pipeline that ingests SVG icons and outputs optimized PNGs for mobile devices, applying the Gauss‑Wiener filter improves visual clarity without manual editing.
 * 4. When generating chart images from SVG sources for PDF reports, the code ensures the rasterized PNG has reduced blur, making the graphics look crisp in the final document.
 * 5. When creating a batch process to convert legacy SVG files to PNG for a content management system, the built‑in filter cleans up artifacts caused by rasterization, delivering cleaner images for end users.
 */
