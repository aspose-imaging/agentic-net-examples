// HOW-TO: Apply Median Filter to ODG Image and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image odgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    odgImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to reduce speckle noise in an ODG diagram before publishing it as a high‑quality PNG for web display.
 * 2. When an application imports OpenDocument graphics and must preprocess them with a median filter to improve visual clarity before saving as PNG thumbnails.
 * 3. When a batch conversion tool must clean up scanned ODG illustrations by applying a 3×3 median filter and then export them to PNG for archival.
 * 4. When a reporting system generates charts in ODG format and requires noise‑free PNG images for inclusion in PDF reports.
 * 5. When a mobile app downloads ODG assets, applies a median filter to smooth edges, and converts them to PNG for efficient rendering on the device.
 */
