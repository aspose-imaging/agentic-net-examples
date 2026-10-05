// HOW-TO: Apply Magic Wand Selection at Cursor Position in C# with Aspose Imaging (Aspose.Imaging for .NET)
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
                int cursorX = 100;
                int cursorY = 100;

                MagicWandTool.Select(image, new MagicWandSettings(cursorX, cursorY)).Apply();

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to let users click a button to automatically select and mask an area of a PNG image based on the mouse cursor location.
 * 2. When building a photo‑editing desktop app that uses Aspose.Imaging to perform Magic Wand selections without manual region drawing.
 * 3. When implementing an automated screenshot tool that isolates a region around the cursor for further processing or saving as a PNG.
 * 4. When creating a graphics workflow that programmatically extracts objects from raster images by seeding the Magic Wand at runtime coordinates.
 * 5. When integrating image segmentation into a C# WinForms or WPF interface where a button triggers a mask generation using the current cursor point.
 */
