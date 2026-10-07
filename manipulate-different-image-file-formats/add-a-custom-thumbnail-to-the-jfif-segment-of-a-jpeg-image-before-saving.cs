// HOW-TO: Add Custom JFIF Thumbnail to JPEG Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                using (JpegImage thumbImg = (JpegImage)Image.Load(thumbnailPath))
                {
                    image.Jfif = new JFIFData();
                    image.Jfif.Thumbnail = thumbImg;
                }

                JpegOptions saveOptions = new JpegOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to embed a preview thumbnail inside a JPEG file so photo‑management software can display a quick preview without loading the full image.
 * 2. When generating JPEGs for digital cameras or mobile apps that require a JFIF thumbnail for compatibility with older devices.
 * 3. When creating an image archive where each JPEG must contain a custom thumbnail representing a different resolution or watermark.
 * 4. When updating existing JPEGs to include a new thumbnail without re‑encoding the entire image, preserving the original quality.
 * 5. When building a C# service that programmatically adds product preview thumbnails to JPEG product images for e‑commerce platforms.
 */
