using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

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
                // Adjust brightness (+50)
                RasterImage raster = (RasterImage)image;
                raster.AdjustBrightness(50);

                // Set smoothing mode for PNG export
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = Aspose.Imaging.SmoothingMode.HighQuality
                    }
                };

                // Save the brightened image as PNG
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
 * 1. When a developer needs to increase the brightness of a Photoshop PSD file and export the result as a high‑quality PNG for web publishing.
 * 2. When an automated image‑processing pipeline must adjust the luminance of layered PSD assets and ensure smooth rendering by setting the PNG smoothing mode to HighQuality.
 * 3. When a desktop application converts user‑uploaded PSD designs to PNG thumbnails while applying a brightness boost to improve visibility on low‑light displays.
 * 4. When a batch job processes a folder of PSD files, brightens each image by a fixed amount, and saves them as PNGs with anti‑aliasing for print‑ready previews.
 * 5. When a C# service integrates Aspose.Imaging to modify PSD artwork for marketing materials, enhancing brightness and exporting to PNG with optimal smoothing for digital ads.
 */