// HOW-TO: How To Deskew A PSD And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    rasterImage.NormalizeAngle();
                }

                var pngOptions = new PngOptions();
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
 * 1. When you need to correct a tilted Photoshop PSD before publishing it as a web‑ready PNG.
 * 2. When an automated pipeline must straighten scanned mockups saved as PSD files and output them in lossless PNG format.
 * 3. When a desktop application processes user‑uploaded PSD layers and requires a deskewed PNG preview.
 * 4. When batch converting a collection of misaligned PSD assets to correctly oriented PNGs for a game UI.
 * 5. When integrating Aspose.Imaging in a C# service that normalizes image angles and saves the result as PNG for downstream analytics.
 */
