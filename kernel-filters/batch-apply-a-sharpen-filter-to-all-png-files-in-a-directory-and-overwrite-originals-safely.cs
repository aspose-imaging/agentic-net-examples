// HOW-TO: Batch Sharpen All PNG Images In A Folder Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
            string inputDirectory = "InputImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(filePath, false)
                    };

                    raster.Save(filePath, options);
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
 * 1. When you need to automatically enhance the sharpness of dozens of product photos stored as PNGs before uploading them to an e‑commerce site.
 * 2. When a desktop application must process a folder of scanned PNG documents and apply a sharpening filter to improve readability without creating duplicate files.
 * 3. When a batch job has to prepare PNG assets for a game by sharpening them in place to meet visual quality standards.
 * 4. When you want to integrate Aspose.Imaging into a C# service that cleans up user‑uploaded PNG avatars by applying a sharpen filter and overwriting the originals safely.
 * 5. When a CI/CD pipeline should run a post‑build step that sharpens all generated PNG screenshots to enhance detail before publishing them.
 */
