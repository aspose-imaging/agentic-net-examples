using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

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
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new MagicWandSettings(150, 150) { Threshold = 30 })
                    .Apply();

                Graphics graphics = new Graphics(image);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, image.Width, image.Height));
                }

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
 * 1. When a developer needs to isolate a complex region in a PNG photograph—combining two similar color areas and removing a smaller overlapping part—so they can recolor the entire image with a solid red overlay.
 * 2. When building an automated batch process that highlights specific objects in scanned PNG documents by creating a custom selection with Magic Wand union and subtraction before applying a uniform fill.
 * 3. When creating a C# tool that prepares graphics for UI themes by selecting multiple background zones in a raster image, excluding logo areas, and then filling the remaining canvas with a single color.
 * 4. When implementing a photo‑editing feature that lets users click to select adjacent color regions, merge them, cut out unwanted spots, and instantly repaint the whole picture using a SolidBrush in Aspose.Imaging.
 * 5. When generating marketing assets where a designer wants to replace the original colors of a PNG logo with a brand‑specific red by programmatically selecting combined regions and applying a solid fill.
 */