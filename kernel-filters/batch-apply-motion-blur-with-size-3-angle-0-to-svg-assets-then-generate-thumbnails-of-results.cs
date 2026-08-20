// HOW-TO: Batch Apply Motion Blur to SVGs and Create PNG Thumbnails in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "InputSvgs";
            string outputDir = "OutputSvgs";
            string thumbDir = "Thumbnails";

            // Ensure output directories exist
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(thumbDir);

            // Process each SVG file in the input directory
            foreach (string file in Directory.GetFiles(inputDir, "*.svg"))
            {
                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Rasterize SVG to PNG
                string baseName = Path.GetFileNameWithoutExtension(file);
                string rasterPath = Path.Combine(outputDir, baseName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(rasterPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    svgImage.Save(rasterPath, pngOptions);
                }

                // Apply motion blur (size 3, angle 0) using MotionWienerFilterOptions
                string filteredPath = Path.Combine(outputDir, baseName + "_filtered.png");
                Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));

                using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
                {
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(3, 1.0, 0.0));
                    raster.Save(filteredPath);
                }

                // Generate thumbnail of the filtered image
                string thumbPath = Path.Combine(thumbDir, baseName + "_thumb.png");
                Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));

                using (RasterImage filtered = (RasterImage)Image.Load(filteredPath))
                {
                    const int thumbSize = 150;
                    int newWidth, newHeight;
                    if (filtered.Width >= filtered.Height)
                    {
                        newWidth = thumbSize;
                        newHeight = (int)(filtered.Height * ((float)thumbSize / filtered.Width));
                    }
                    else
                    {
                        newHeight = thumbSize;
                        newWidth = (int)(filtered.Width * ((float)thumbSize / filtered.Height));
                    }

                    filtered.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                    filtered.Save(thumbPath);
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
 * 1. When you need to add a subtle motion‑blur effect to a large collection of SVG icons before publishing them on a website.
 * 2. When you must convert vector SVG graphics to raster PNG files while preserving original dimensions for downstream processing.
 * 3. When you want to automatically generate small preview thumbnails of filtered SVG images for a digital asset management system.
 * 4. When you are building a C# batch‑processing tool that applies the same filter settings (size 3, angle 0) to every SVG in a folder.
 * 5. When you require a repeatable workflow that rasterizes, filters, and saves SVG assets using Aspose.Imaging without manual intervention.
 */
