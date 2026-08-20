// HOW-TO: Crop Central 400x400 BMP, Apply Feathered Magic Wand, Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Ensure image data is cached for better performance
                if (!image.IsCached)
                    image.CacheData();

                // Crop central 400x400 area
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                image.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                // Apply feathered Magic Wand selection at the center of the cropped area
                int centerX = cropWidth / 2;
                int centerY = cropHeight / 2;
                MagicWandTool.Select(image, new MagicWandSettings(centerX, centerY))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save the result as PNG
                PngOptions options = new PngOptions();
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
 * 1. When you need to extract a centered 400 × 400 region from a large BMP file and deliver it as a PNG for web thumbnails.
 * 2. When you want to isolate the central area of an image using a feathered Magic Wand selection to create smooth edges before saving.
 * 3. When you are building a C# batch‑processing tool that converts legacy BMP assets to PNG while applying selective feathering for better visual quality.
 * 4. When you must programmatically crop and mask scanned documents so only the central portion is retained and exported in a lossless format.
 * 5. When you are preparing product photos for an e‑commerce catalog, cropping the focus area and applying a soft feathered mask before saving as PNG.
 */
