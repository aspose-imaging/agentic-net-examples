// HOW-TO: Apply Median Filter to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                        raster.Filter(raster.Bounds, medianOptions);

                        var jpegOptions = new JpegOptions();
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
 * 1. When you need to reduce salt‑and‑pepper noise in an OTG graphic before delivering a compressed JPEG for web display.
 * 2. When a legacy workflow requires converting proprietary OTG files to a widely supported JPEG format while applying a median filter to improve visual quality.
 * 3. When you are building a C# batch‑processing tool that cleans up scanned OTG images and outputs them as JPEGs for archival storage.
 * 4. When an automated pipeline must read an OTG image, apply a 3×3 median filter, and save the result as a JPEG using Aspose.Imaging without intermediate files on disk.
 * 5. When you want to ensure consistent JPEG output from OTG sources by first converting to PNG in memory, filtering, and then saving with Aspose.Imaging in a .NET application.
 */
