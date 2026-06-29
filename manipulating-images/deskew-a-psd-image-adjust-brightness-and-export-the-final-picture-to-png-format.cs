using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
                raster.AdjustBrightness(30);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to automatically correct the tilt of scanned Photoshop (PSD) files, enhance their visibility by increasing brightness, and deliver the result as a web‑friendly PNG using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must preprocess product mockups stored as PSDs—deskewing them, brightening the colors, and converting to PNG for fast page loads.
 * 3. When a digital archiving system has legacy PSD documents that require orientation correction and brightness adjustment before being stored as lossless PNG thumbnails.
 * 4. When a mobile app backend processes user‑uploaded PSD artwork, straightens the image, boosts its brightness, and saves it as PNG to be displayed on various devices.
 * 5. When a printing workflow needs to prepare PSD source files by removing skew, improving contrast, and exporting to PNG for proofing or preview generation.
 */