using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)image;
                RasterImage raster = (RasterImage)dng;
                raster.AdjustGamma(2.2f);

                PngOptions options = new PngOptions();
                dng.Save(outputPath, options);
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
 * 1. When a photographer uses Aspose.Imaging for .NET to convert raw DNG files to web‑ready PNGs with a 2.2 gamma correction for consistent browser display.
 * 2. When an e‑commerce platform processes product images stored as DNG, applies AdjustGamma via C# and saves them as PNG thumbnails for faster page loads.
 * 3. When a scientific imaging tool loads DNG sensor data, uses Aspose.Imaging to adjust gamma and exports the result as PNG for inclusion in research publications.
 * 4. When a mobile‑app backend receives raw DNG uploads, normalizes brightness with raster.AdjustGamma in C# and stores the images as PNG for efficient delivery.
 * 5. When a digital archiving system batch‑processes DNG scans, corrects gamma to the standard 2.2 using Aspose.Imaging and saves the output as PNG for long‑term preservation.
 */