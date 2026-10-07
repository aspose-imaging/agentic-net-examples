// HOW-TO: Feather Mask Edges on High Resolution TIFF with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var settings = new MagicWandSettings(0, 0);
                var featherSettings = new FeatheringSettings { Size = 5 };
                MagicWandTool.Select(image, settings)
                    .GetFeathered(featherSettings)
                    .Apply();

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to smooth the edges of a selection mask in a large TIFF before further processing or printing.
 * 2. When preparing scanned documents for OCR and you want to reduce jagged mask borders that cause recognition errors.
 * 3. When creating GIS raster layers and you need a soft transition between masked and unmasked areas to avoid visual artifacts.
 * 4. When generating medical imaging reports and you must feather mask outlines to meet regulatory image quality standards.
 * 5. When building a photo‑editing workflow that automatically applies a 5‑pixel feather to user‑drawn masks on high‑resolution images.
 */
