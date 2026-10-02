// HOW-TO: Invert Magic Wand Selection on TIFF and Fill Inverted Area with White in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

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
                // Invert selection using Magic Wand at point (0,0)
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                // Fill the entire image with white
                int width = image.Width;
                int height = image.Height;
                int totalPixels = width * height;
                Aspose.Imaging.Color[] whitePixels = new Aspose.Imaging.Color[totalPixels];
                for (int i = 0; i < totalPixels; i++)
                {
                    whitePixels[i] = Aspose.Imaging.Color.White;
                }
                image.SavePixels(new Aspose.Imaging.Rectangle(0, 0, width, height), whitePixels);

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
 * 1. When you need to remove a colored background from a scanned TIFF document and replace it with a solid white canvas using C#.
 * 2. When preparing TIFF images for OCR and you must ensure that all non‑selected regions are white to improve text recognition accuracy.
 * 3. When cleaning up old map scans by selecting a specific color range with the Magic Wand tool, inverting the selection, and painting the remaining area white.
 * 4. When generating a white‑filled mask from a TIFF image for later compositing or layering in a graphics processing pipeline.
 * 5. When automating batch processing of TIFF files to standardize the background color to white before archiving or publishing.
 */
