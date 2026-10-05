// HOW-TO: Batch Convert Images to PNG with 5 Pixel Border Crop in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                    {
                        image.CacheData();
                    }

                    int newWidth = image.Width - 10;
                    int newHeight = image.Height - 10;
                    if (newWidth > 0 && newHeight > 0)
                    {
                        Rectangle cropRect = new Rectangle(5, 5, newWidth, newHeight);
                        image.Crop(cropRect);
                    }

                    using (PngOptions options = new PngOptions())
                    {
                        options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to prepare a large set of photos for a web gallery by converting them to PNG and removing a uniform 5‑pixel border from each image.
 * 2. When an e‑commerce platform requires product images in PNG format with consistent cropping to align thumbnails across the catalog.
 * 3. When a mobile app processes user‑uploaded pictures and must batch‑convert them to PNG while trimming unwanted edges before storage.
 * 4. When a document generation system automatically converts scanned pages to PNG and removes a fixed margin to improve layout consistency.
 * 5. When a digital asset management workflow needs to standardize diverse image files to PNG and apply the same border crop to all assets in a folder.
 */
