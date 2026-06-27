using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions();

                EmfRasterizationOptions vectorOptions = new EmfRasterizationOptions
                {
                    PageSize = tiff.Size,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                };

                pngOptions.VectorRasterizationOptions = vectorOptions;

                tiff.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert multi‑page TIFF documents that contain EMF‑encoded text into high‑resolution PNG images while preserving the text as vector shapes for crisp rendering.
 * 2. When an application must generate web‑ready PNG thumbnails from scanned TIFF files that include embedded EMF captions, ensuring the text remains sharp at any zoom level.
 * 3. When a reporting tool has to export printed TIFF reports with vector‑based annotations to PNG format for inclusion in PDFs without losing text quality.
 * 4. When a migration script has to batch‑process legacy TIFF assets containing EMF graphics and produce PNG assets that can be displayed on modern browsers.
 * 5. When a GIS or CAD system requires converting TIFF maps with embedded EMF labels into PNG tiles while keeping the label text rendered as vectors for accurate scaling.
 */