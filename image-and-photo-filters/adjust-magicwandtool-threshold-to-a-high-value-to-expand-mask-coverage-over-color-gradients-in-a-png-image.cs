using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100) { Threshold = 250 })
                    .Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When a developer needs to remove a complex gradient background from a PNG logo to create a transparent version for web use.
 * 2. When an image processing pipeline must isolate a smoothly shaded object in a PNG photograph for automated cropping.
 * 3. When a UI designer wants to generate a high‑resolution PNG sprite sheet where the mask must cover subtle color transitions between frames.
 * 4. When a batch script processes scanned PNG documents with watercolor washes, requiring a high MagicWandTool Threshold to select the entire wash area for OCR preprocessing.
 * 5. When a game developer prepares PNG textures with soft edges and needs the MagicWandTool to expand the mask across the gradient for seamless blending.
 */