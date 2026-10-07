// HOW-TO: Increase TIFF Brightness by 20 and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\enhanced.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var raster = image as RasterImage;
                if (raster != null)
                {
                    raster.AdjustBrightness(20);
                    var options = new PngOptions();
                    raster.Save(outputPath, options);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image format.");
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
 * 1. When you need to brighten scanned TIFF documents by a fixed amount before converting them to PNG for web display.
 * 2. When an application must automatically enhance low-light satellite TIFF images and store the result as lossless PNG files.
 * 3. When a batch process has to adjust the brightness of medical TIFF scans by 20 units and output them in a PNG format for reporting tools.
 * 4. When a C# service integrates Aspose.Imaging to improve the visibility of archival TIFF photos before delivering them as PNG thumbnails.
 * 5. When developers want to programmatically increase the brightness of a TIFF image and save the edited version as PNG without using external image editors.
 */
