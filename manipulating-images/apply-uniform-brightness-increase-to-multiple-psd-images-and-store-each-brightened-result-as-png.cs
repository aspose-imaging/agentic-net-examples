// HOW-TO: Increase Brightness of Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.psd");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.AdjustBrightness(50);

                    PngOptions pngOptions = new PngOptions();
                    pngOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑brighten a collection of Photoshop PSD layers for a marketing campaign and deliver the results as web‑ready PNGs using C#.
 * 2. When an automated build process must normalize the lighting of product mockups stored as PSD files before publishing them to an e‑commerce site.
 * 3. When a desktop application has to convert user‑uploaded PSD artwork to PNG while applying a consistent brightness boost for better visibility on mobile devices.
 * 4. When a digital asset management system requires a script to preprocess PSD assets by increasing their brightness and storing the edited versions in a PNG cache folder.
 * 5. When a photo‑editing workflow needs to quickly apply the same brightness level to dozens of PSD files and export them as lossless PNGs without manual intervention.
 */
