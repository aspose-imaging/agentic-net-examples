// HOW-TO: Batch Sharpen PNG Images and Overwrite Originals Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputPngs";
            string outputDirectory = "InputPngs";

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    PngOptions options = new PngOptions();
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
 * 1. When a developer needs to automatically improve the clarity of a large set of product photos stored as PNGs before publishing them on an e‑commerce site.
 * 2. When a desktop application must process user‑uploaded screenshots, apply a sharpening filter, and replace the original files to save disk space.
 * 3. When a batch job is required to enhance scanned documents in PNG format for better OCR accuracy by sharpening the images in place.
 * 4. When a photo‑editing tool wants to provide a one‑click “sharpen all” feature that loops through a folder of PNG assets and overwrites each with the enhanced version.
 * 5. When a CI/CD pipeline needs to prepare marketing assets by sharpening PNG graphics during the build process without creating duplicate files.
 */
