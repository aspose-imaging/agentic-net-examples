using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\sample.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                BmpOptions bmpOptions = new BmpOptions
                {
                    KeepMetadata = true
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert user‑uploaded WebP photos to BMP for compatibility with legacy Windows applications that only accept BMP files.
 * 2. When an e‑commerce platform must generate high‑resolution BMP thumbnails from WebP product images while preserving the original color profile for accurate color representation.
 * 3. When a digital asset management system imports WebP graphics and stores them as BMP to maintain lossless quality for archival purposes.
 * 4. When a printing workflow requires converting WebP artwork to BMP to ensure the printer driver reads the exact resolution and embedded ICC profile.
 * 5. When a game engine loads textures supplied as WebP and needs to save them as BMP for tools that only support BMP while keeping the original metadata intact.
 */