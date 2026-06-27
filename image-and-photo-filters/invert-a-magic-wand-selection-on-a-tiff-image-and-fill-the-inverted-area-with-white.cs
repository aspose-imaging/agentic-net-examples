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
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                Color[] pixels = image.LoadPixels(image.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    if (pixels[i].A == 0)
                    {
                        pixels[i] = Color.FromArgb(255, 255, 255, 255);
                    }
                }
                image.SavePixels(image.Bounds, pixels);

                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a developer needs to remove the background of a scanned TIFF document and replace it with a solid white canvas for printing or OCR.
 * 2. When an image‑processing pipeline must invert a Magic Wand selection on a multi‑page TIFF and fill the transparent regions with white to ensure consistent appearance across viewers.
 * 3. When a C# application has to clean up scanned forms by selecting the foreground, inverting the selection, and converting all fully transparent pixels to opaque white for archival storage.
 * 4. When a batch conversion tool requires using Aspose.Imaging to load a TIFF, apply a Magic Wand selection inversion, and save the result with default TIFF options for downstream GIS analysis.
 * 5. When a developer wants to programmatically replace the empty (alpha‑zero) areas of a raster image with white after a Magic Wand operation to meet PDF/A compliance standards.
 */