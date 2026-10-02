// HOW-TO: Create JPEG Thumbnails for a Folder of Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
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
            string outputDirectory = Path.Combine(baseDir, "Output", "Thumbnails");

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage raster)
                    {
                        int maxDim = 150;
                        double scale = Math.Min((double)maxDim / raster.Width, (double)maxDim / raster.Height);
                        if (scale > 1) scale = 1;
                        int newWidth = Math.Max(1, (int)(raster.Width * scale));
                        int newHeight = Math.Max(1, (int)(raster.Height * scale));

                        raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                        using (JpegOptions jpegOptions = new JpegOptions())
                        {
                            jpegOptions.Quality = 90;
                            raster.Save(outputPath, jpegOptions);
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
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
 * 1. When you need to generate small preview images for a web gallery from a batch of high‑resolution JPEG photos.
 * 2. When you want to automatically create thumbnail versions of user‑uploaded pictures before storing them in a separate directory.
 * 3. When you are building a desktop application that displays image lists and requires uniformly sized thumbnails for faster UI rendering.
 * 4. When you must process a large collection of JPEG files on a server and save reduced‑size copies for email attachments or API responses.
 * 5. When you need to resize images while preserving aspect ratio and ensure the thumbnails are saved with consistent naming in a subfolder.
 */
