using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "thumbnail.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                tiff.Save(outputPath, new WebPOptions());
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
 * 1. When a developer needs to generate a lightweight preview of a high‑resolution TIFF document for web display by extracting its embedded thumbnail and converting it to WebP.
 * 2. When an application must create a small, lossless‑compatible thumbnail from scanned TIFF images to improve page load speed in a gallery viewer.
 * 3. When a digital asset management system requires extracting the built‑in thumbnail from multi‑page TIFF files and storing it as a WebP file for mobile devices.
 * 4. When a batch‑processing script has to convert TIFF metadata thumbnails into WebP format to standardize image assets across a cloud storage pipeline.
 * 5. When a C# service needs to verify the presence of a TIFF thumbnail and save it as a WebP image for use in email newsletters or social media previews.
 */