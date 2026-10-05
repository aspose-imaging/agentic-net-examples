// HOW-TO: Create Fixed Size BMP Thumbnails for Gallery Display in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.bmp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int thumbWidth = 150;
                    int thumbHeight = 150;
                    image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    using (BmpOptions options = new BmpOptions())
                    {
                        image.Save(outputPath, options);
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
 * 1. When building an online photo gallery that needs fast‑loading preview images from high‑resolution BMP files.
 * 2. When generating thumbnail previews for a desktop application that displays BMP assets in a searchable catalog.
 * 3. When preparing BMP images for an e‑commerce product list where each item must show a uniform 150×150 pixel preview.
 * 4. When creating a batch‑processing script to resize BMP scans for a digital archive’s web interface.
 * 5. When automating thumbnail creation for a content‑management system that stores original BMP files but serves smaller previews to users.
 */
