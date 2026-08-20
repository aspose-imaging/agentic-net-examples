// HOW-TO: Apply 5‑Pixel Feather To Mask Edges Of TIFF With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .GetFeathered(new FeatheringSettings { Size = 5 })
                    .Apply();

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When you need to soften the boundaries of a selection mask in a large TIFF before printing to avoid harsh edges.
 * 2. When preparing satellite or aerial imagery in TIFF format for GIS analysis and you want smooth mask transitions to improve visual blending.
 * 3. When creating medical scan overlays in high‑resolution TIFF files and require feathered edges to prevent abrupt visual artifacts.
 * 4. When automating a batch process that refines scanned document masks in TIFFs to enhance OCR accuracy by smoothing edge noise.
 * 5. When developing a C# application that dynamically adjusts mask softness on TIFF images for web‑based image editors or viewers.
 */
