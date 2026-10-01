// HOW-TO: Apply Median Filter to OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.otg";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                    raster.Filter(raster.Bounds, medianOptions);

                    var saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, saveOptions);
                }
                else if (image is VectorImage vector)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var tempOptions = new PngOptions
                        {
                            Source = new StreamSource(ms)
                        };
                        vector.Save(ms, tempOptions);
                        ms.Position = 0;

                        using (RasterImage raster2 = (RasterImage)Image.Load(ms))
                        {
                            var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                            raster2.Filter(raster2.Bounds, medianOptions);

                            var saveOptions = new PngOptions
                            {
                                Source = new FileCreateSource(outputPath, false)
                            };
                            raster2.Save(outputPath, saveOptions);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type.");
                    return;
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
 * 1. When you need to reduce noise in an OTG graphic before exporting it as a high‑quality PNG for web display.
 * 2. When converting vector‑based OTG files to raster PNGs while preserving image clarity by applying a median filter.
 * 3. When processing scanned OTG diagrams that contain speckles and you want a cleaner PNG output for documentation.
 * 4. When automating a batch job that reads OTG assets, denoises them, and stores the results as PNG files for a mobile app.
 * 5. When integrating Aspose.Imaging into a C# service that receives OTG uploads, applies noise reduction, and returns PNG thumbnails.
 */
