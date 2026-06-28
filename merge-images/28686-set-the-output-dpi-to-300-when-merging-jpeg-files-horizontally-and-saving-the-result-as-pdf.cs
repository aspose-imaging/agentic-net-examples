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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pngOptions = new PngOptions())
                    {
                        img.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑convert a collection of high‑resolution JPEG photographs to lossless PNG files for archival or further image processing in a .NET application.
 * 2. When an e‑commerce platform must generate web‑optimized PNG thumbnails from user‑uploaded JPEG product images to ensure consistent transparency support.
 * 3. When a medical imaging system requires converting scanned JPEG X‑ray images to PNG to preserve pixel data before applying Aspose.Imaging analysis algorithms.
 * 4. When a content management system automates the migration of legacy JPEG assets to PNG format to meet corporate branding guidelines that mandate lossless images.
 * 5. When a desktop utility needs to read JPEG files from a folder, validate their existence, and save them as PNG using Aspose.Imaging’s RasterImage class for cross‑platform compatibility.
 */