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
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    // Prepare PNG options for the current page
                    var pngOptions = new PngOptions
                    {
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    // Set vector rasterization options
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    // Rasterize the page to a memory stream
                    using (var ms = new MemoryStream())
                    {
                        image.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized image and apply motion blur filter
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(6, 1.0, 75.0));

                            string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            raster.Save(outputPath, new PngOptions());
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
 * 1. When generating animated thumbnails for a multi‑page SVG brochure, a developer can rasterize each page to PNG, apply a motion‑blur effect (size 6, angle 75) and save the results for quick preview.
 * 2. When preparing print‑ready assets from a multi‑page vector illustration, a developer may need to convert each SVG page to a raster PNG, add motion blur to simulate motion in a catalog layout, and store the images in an output folder.
 * 3. When building a web service that returns blurred PNG snapshots of each layer in a multi‑page SVG diagram, a developer can loop through the pages, rasterize them, apply a MotionWienerFilterOptions blur, and return the files.
 * 4. When creating a visual effect pipeline for an e‑learning module that uses multi‑page SVG slides, a developer can use Aspose.Imaging to apply a consistent motion blur (size 6, angle 75) to every slide before exporting them as PNGs.
 * 5. When automating quality‑control tests that compare original SVG pages with their blurred PNG counterparts, a developer can iterate over each page, rasterize, apply the motion blur filter, and save the output for side‑by‑side analysis.
 */