// HOW-TO: Resize PNG to Half Width and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = (int)(image.Height * (newWidth / (double)image.Width));

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate smaller thumbnail JPEGs from high‑resolution PNG assets for faster web page loading.
 * 2. When an e‑commerce platform must convert product PNG images to compressed JPEGs while keeping the original aspect ratio.
 * 3. When a mobile app processes user‑uploaded PNG photos, reduces their width by 50 % and stores them as JPEGs with a specific quality setting.
 * 4. When a batch‑processing script prepares print‑ready images by resizing PNGs and saving them as JPEGs to meet file‑size limits.
 * 5. When a content‑management system automatically creates preview JPEGs from uploaded PNG files, ensuring consistent dimensions and quality.
 */
