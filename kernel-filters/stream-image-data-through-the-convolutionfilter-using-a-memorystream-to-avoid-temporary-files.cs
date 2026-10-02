// HOW-TO: Apply Emboss Convolution Filter to JPEG Using MemoryStream in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (var ms = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine("Loaded image is not a raster image.");
                        return;
                    }

                    if (!raster.IsCached)
                        raster.CacheData();

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                    raster.Filter(raster.Bounds, filterOptions);

                    var saveOptions = new JpegOptions();
                    image.Save(outputPath, saveOptions);
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
 * 1. When you need to apply an emboss effect to a JPEG image in a web service without creating intermediate files.
 * 2. When processing large batches of images in memory to improve performance and reduce disk I/O in a C# application.
 * 3. When you want to cache raster data before applying a filter to ensure the image is fully loaded in memory.
 * 4. When you must save the filtered image directly to a specific folder with JPEG compression settings in an automated workflow.
 * 5. When you need to handle missing input files gracefully while applying image filters in a .NET console utility.
 */
