// HOW-TO: Sharpen PNG Image with 5x5 Filter Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\sharpened.png";

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
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen5x5);

                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to enhance the details of a scanned PNG drawing without altering its original brightness for a web gallery.
 * 2. When an automated batch process must apply a 5x5 sharpening convolution to raster images before printing high‑resolution brochures.
 * 3. When a photo‑editing application requires a C# routine to sharpen user‑uploaded PNG files while keeping the exposure unchanged.
 * 4. When you want to improve the clarity of map or blueprint PNG files in a GIS system using Aspose.Imaging’s built‑in filter.
 * 5. When a server‑side service must quickly sharpen PNG assets for a mobile app without introducing color shifts.
 */
