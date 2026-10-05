// HOW-TO: Convert CDR to PNG with Alpha Channel Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    CompressionLevel = 9,
                    ColorType = PngColorType.IndexedColor,
                    Palette = ColorPaletteHelper.GetCloseTransparentImagePalette(image, 256),
                    FilterType = PngFilterType.Avg
                };

                image.Save(outputPath, options);
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
 * 1. When a designer needs to export transparent vector artwork from CorelDRAW (CDR) to web‑ready PNG files while keeping the original alpha channel intact.
 * 2. When an automated build pipeline must batch‑convert CDR assets to compressed PNGs for mobile apps, ensuring the images retain their transparency.
 * 3. When a graphics‑processing service uses Aspose.Imaging in C# to generate PNG thumbnails from CDR files without losing semi‑transparent layers.
 * 4. When a legacy system stores icons in CDR format and requires conversion to indexed‑color PNGs with maximum compression for faster loading.
 * 5. When a content‑management system programmatically transforms client‑provided CDR logos into PNGs with preserved transparency for branding on websites.
 */
