using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.gif";

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
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Subtract(new MagicWandSettings(50, 50))
                    .GetFeathered(new FeatheringSettings { Size = 5 })
                    .Apply();

                var gifOptions = new GifOptions();
                image.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to remove a specific unwanted region from a photo (e.g., a watermark or logo) and create a smooth‑edged mask before exporting the result as a GIF for web display.
 * 2. When building an e‑commerce site that requires product images with clean, feathered cut‑outs saved as lightweight GIF files to improve page load speed.
 * 3. When generating animated GIF frames where certain background elements must be subtracted and the remaining subject’s edges softened to avoid harsh transitions.
 * 4. When preparing user‑uploaded images for a social‑media app that automatically strips out a defined area (such as a banner) and applies feathering to maintain visual quality before saving as GIF.
 * 5. When creating a GIF thumbnail from a larger JPEG where a portion of the image is irrelevant, and the developer wants to subtract that area, feather the edges, and output a compact GIF for preview purposes.
 */