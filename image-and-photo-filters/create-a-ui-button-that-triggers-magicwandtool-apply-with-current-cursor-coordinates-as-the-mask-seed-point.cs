// HOW-TO: Apply Magic Wand Selection at Cursor Position in C# (Aspose.Imaging for .NET)
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

            // Placeholder cursor coordinates; replace with actual cursor values if available
            int cursorX = 100;
            int cursorY = 100;

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(cursorX, cursorY))
                    .Apply();

                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
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
 * 1. When you need to let users click on a photo in a Windows Forms app and automatically select the region around the click for background removal using Aspose.Imaging’s MagicWandTool.
 * 2. When you want to programmatically generate a mask from a specific point in a PNG image to create transparent cut‑outs for UI overlays.
 * 3. When building an image‑editing feature that isolates objects under the mouse pointer for further processing such as color correction or cropping.
 * 4. When automating batch processing where a predefined seed point is used to extract similar‑colored areas from multiple PNG files.
 * 5. When integrating a quick “click‑to‑select” tool in a C# graphics editor that saves the selected area with alpha channel preservation.
 */
