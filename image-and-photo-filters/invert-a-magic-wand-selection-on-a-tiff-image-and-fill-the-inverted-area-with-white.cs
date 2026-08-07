using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                Color[] pixels = image.LoadPixels(image.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    if (pixels[i].A == 0)
                    {
                        pixels[i] = Color.White;
                    }
                }
                image.SavePixels(image.Bounds, pixels);

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
 * 1. When a developer needs to remove a background from a scanned document and replace the removed area with a white canvas in a multi‑page TIFF file.
 * 2. When an imaging application must isolate and invert a region selected by a Magic Wand tool on a TIFF image to highlight the opposite area for further processing.
 * 3. When a batch conversion script has to ensure that any transparent pixels left after a Magic Wand selection are filled with white before saving the result as a TIFF.
 * 4. When a medical imaging system requires clearing unwanted artifacts by selecting them with a Magic Wand, inverting the mask, and painting the rest of the image white in C#.
 * 5. When a developer is building a PDF generation pipeline that needs to preprocess TIFF pages by inverting a Magic Wand selection and converting transparent regions to solid white for consistent rendering.
 */