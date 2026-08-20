// HOW-TO: Invert Magic Wand Selection and Fill with White in TIFF using C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using magic wand at point (10,10) and invert it
                ImageBitMask mask = MagicWandTool
                    .Select(image, new MagicWandSettings(10, 10))
                    .Invert();

                // Load all pixels from the image
                Color[] pixels = image.LoadPixels(image.Bounds);

                // Fill inverted mask area with white
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        if (mask.GetByteOpacity(x, y) > 0)
                        {
                            pixels[y * image.Width + x] = Color.White;
                        }
                    }
                }

                // Save modified pixels back to the image
                image.SavePixels(image.Bounds, pixels);

                // Save the result as TIFF
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
 * 1. When you need to remove a background object from a scanned TIFF document by selecting the foreground with a magic wand and turning the remaining area white.
 * 2. When preparing scanned maps for printing and you want to whiten all regions outside a selected area without manually editing each pixel.
 * 3. When creating a preprocessing step for OCR where non‑text regions of a TIFF image must be masked out and replaced with a uniform white background.
 * 4. When automating the cleanup of medical imaging TIFF files by inverting a region selected at a specific coordinate and filling it with white to meet archival standards.
 * 5. When developing a batch tool that programmatically isolates a region of interest in TIFF photos and clears the rest of the image to white for consistent downstream analysis.
 */
