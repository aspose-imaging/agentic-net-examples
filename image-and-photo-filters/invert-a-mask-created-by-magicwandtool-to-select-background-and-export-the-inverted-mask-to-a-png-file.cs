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
                    .Select(image, new MagicWandSettings(120, 100))
                    .Invert()
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
 * 1. When a developer needs to remove a foreground object from a PNG and keep the background by inverting a MagicWand selection.
 * 2. When an application must generate a transparent mask for the background of an image for compositing in a photo‑editing workflow.
 * 3. When a batch‑processing tool has to export the inverted selection as a PNG with an alpha channel for use in web graphics.
 * 4. When a C# service processes user‑uploaded images and needs to isolate the background for automated cropping or resizing.
 * 5. When a developer wants to create a PNG overlay that highlights everything except the area selected by MagicWand for visual effects.
 */