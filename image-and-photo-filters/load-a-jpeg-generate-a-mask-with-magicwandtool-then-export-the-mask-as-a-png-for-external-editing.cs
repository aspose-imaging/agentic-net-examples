// HOW-TO: Create PNG Mask from JPEG Using Magic Wand Tool in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "mask.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Apply();

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to isolate a specific region of a JPEG photo for further editing in Photoshop, you can generate a PNG mask with Aspose.Imaging’s MagicWandTool.
 * 2. When building a web application that lets users select objects in uploaded JPEG images and then export the selection as a transparent PNG overlay.
 * 3. When preparing assets for a game engine where the collision shape must be derived from a JPEG texture and saved as a binary mask image.
 * 4. When automating batch processing of product photos to create cut‑out masks for e‑commerce catalogs.
 * 5. When integrating image analysis into a machine‑learning pipeline that requires a binary mask of a JPEG input for segmentation preprocessing.
 */
