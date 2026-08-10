// HOW-TO: Increase PSD Brightness, Apply Anti-Alias Smoothing, Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
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
                RasterImage raster = (RasterImage)image;
                raster.AdjustBrightness(50); // Increase brightness

                Graphics graphics = new Graphics(raster);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
 * 1. When you need to brighten a Photoshop PSD file and export it as a web‑ready PNG with anti‑alias smoothing for an e‑commerce product catalog.
 * 2. When a designer wants to increase the visibility of a dark layer in a PSD before converting it to PNG for mobile app assets.
 * 3. When automating a workflow that adjusts the overall brightness of scanned artwork PSDs and saves them as high‑quality PNGs for print proofs.
 * 4. When preprocessing PSD images for a machine‑learning pipeline, applying brightness correction and smoothing before saving them in PNG format.
 * 5. When creating thumbnails from PSD source files, you can boost brightness, apply anti‑alias smoothing, and output PNGs for faster page loading.
 */
