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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Lazy<RasterImage> lazyImage = new Lazy<RasterImage>(() =>
            {
                Image img = Image.Load(inputPath);
                RasterImage raster = (RasterImage)img;
                if (!raster.IsCached)
                    raster.CacheData();
                return raster;
            });

            using (RasterImage raster = lazyImage.Value)
            {
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to apply a sharpen filter to a PNG file while ensuring the image is loaded only after confirming the file exists, using lazy loading to reduce memory consumption.
 * 2. When an application processes large batches of images and wants to defer loading each RasterImage until the filter operation is actually performed, improving performance on limited resources.
 * 3. When a C# service must validate the input path, create the output directory, and then apply a customizable SharpenFilterOptions (strength 5, radius 4.0) to enhance image details on demand.
 * 4. When a developer wants to guarantee that image data is cached before filtering, using Aspose.Imaging’s RasterImage.CacheData within a lazy‑initialized object to avoid repeated disk reads.
 * 5. When an automated workflow needs to handle missing files gracefully, apply a filter only when necessary, and save the processed result as a PNG using PngOptions, all encapsulated in a try‑catch block.
 */