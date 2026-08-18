// HOW-TO: Convert WebP to BMP Preserving Color Profile and Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.webp";
        string outputPath = @"C:\Images\sample.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                double hRes = webpImage.HorizontalResolution;
                double vRes = webpImage.VerticalResolution;

                BmpOptions bmpOptions = new BmpOptions
                {
                    KeepMetadata = true,
                    ResolutionSettings = new Aspose.Imaging.ResolutionSetting(hRes, vRes)
                };

                webpImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert WebP assets to BMP for legacy Windows applications while keeping the original DPI and color information.
 * 2. When a batch‑processing tool must export user‑uploaded WebP photos to BMP for printing workflows that require exact resolution settings.
 * 3. When integrating image conversion in a C# service that stores BMP thumbnails but must retain the source image’s metadata and color profile.
 * 4. When migrating a web gallery from WebP to BMP format for compatibility with software that only reads BMP files yet demands unchanged image quality.
 * 5. When developing a desktop utility that reads WebP files and saves them as BMP without losing resolution, enabling accurate scaling in downstream graphics editors.
 */
