using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "output.png";

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
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.Transparent
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to export a CorelDRAW (CDR) illustration with a transparent background to a web‑ready PNG while preserving the alpha channel for overlaying on other pages.
 * 2. When a software application generates product mockups in CDR format and must convert them to PNG thumbnails that retain transparency for UI components.
 * 3. When an e‑learning platform imports CDR assets and requires PNG images with preserved alpha to blend seamlessly with slide backgrounds.
 * 4. When a mobile app processes user‑uploaded CDR files and needs to rasterize them to PNG with truecolor‑with‑alpha for high‑quality stickers.
 * 5. When an automated build pipeline converts CDR icons to PNG assets, ensuring the transparent background is retained for use in cross‑platform UI themes.
 */