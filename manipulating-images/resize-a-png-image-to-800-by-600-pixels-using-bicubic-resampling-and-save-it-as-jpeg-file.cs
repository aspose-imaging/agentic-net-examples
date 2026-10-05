// HOW-TO: Resize PNG to 800x600 and Convert to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                JpegOptions jpegOptions = new JpegOptions
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
 * 1. When you need to generate web‑ready thumbnails from high‑resolution PNG assets by resizing them to a standard 800×600 size and saving as a smaller JPEG.
 * 2. When an e‑commerce platform requires product images in JPEG format with a fixed dimension for consistent display across browsers.
 * 3. When a batch‑processing script must convert uploaded PNG logos to 800×600 JPEGs for email newsletters to reduce file size.
 * 4. When a desktop application needs to downscale user‑provided PNG screenshots to a specific resolution before archiving them as JPEGs.
 * 5. When a content‑management system automatically resizes PNG illustrations to 800×600 and stores them as JPEGs for faster page loading.
 */
