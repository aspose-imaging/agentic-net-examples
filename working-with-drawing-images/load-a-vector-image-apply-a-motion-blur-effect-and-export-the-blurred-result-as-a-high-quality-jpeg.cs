using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = vectorImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (var memoryStream = new MemoryStream())
                {
                    vectorImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 45.0));

                        var jpegOptions = new JpegOptions { Quality = 100 };
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When a web application needs to convert user‑uploaded SVG logos into high‑resolution JPEG thumbnails with a motion‑blur effect for a dynamic gallery.
 * 2. When an e‑commerce platform wants to generate product preview images from vector illustrations, apply a subtle motion blur to simulate movement, and save them as high‑quality JPEGs for faster page loads.
 * 3. When a desktop publishing tool must rasterize vector diagrams, add a motion‑blur filter to emphasize direction, and export the result as a JPEG for print‑ready PDFs.
 * 4. When an automated marketing pipeline processes SVG banners, applies a motion‑blur effect to create eye‑catching ad creatives, and outputs them as 100‑quality JPEG files for email campaigns.
 * 5. When a game developer needs to pre‑render SVG UI assets with motion blur, convert them to PNG in memory, then save the final frames as high‑quality JPEGs for texture atlases.
 */