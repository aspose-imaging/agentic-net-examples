using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "mask.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .GetFeathered(new FeatheringSettings() { Size = 1 })
                    .Apply();

                image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to isolate a complex foreground region from a PNG and store the selection as a grayscale BMP mask for later compositing in a batch image‑processing pipeline.
 * 2. When an automated photo‑editing tool must generate a reusable mask to apply consistent feathered edges across multiple images using Aspose.Imaging’s MagicWandTool and C#.
 * 3. When a medical imaging application requires extracting a region of interest from a scan and saving it as a 1‑channel BMP mask to feed into downstream analysis algorithms.
 * 4. When a game‑asset pipeline wants to create alpha‑less silhouette masks from source textures so that artists can reuse them for collision detection or shader effects.
 * 5. When a document‑digitization system needs to separate handwritten annotations from scanned pages and preserve the mask in BMP format for archival and OCR preprocessing.
 */