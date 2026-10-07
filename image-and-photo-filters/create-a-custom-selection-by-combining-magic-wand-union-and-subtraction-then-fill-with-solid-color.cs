// HOW-TO: Create Custom Magic Wand Selection with Union Subtraction and Fill Color in C# (Aspose.Imaging for .NET)
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
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Union(new MagicWandSettings(50, 50))
                    .Subtract(new RectangleMask(20, 20, 30, 30))
                    .Apply();

                var rect = new Rectangle(0, 0, image.Width, image.Height);
                int[] pixels = image.LoadArgb32Pixels(rect);
                for (int i = 0; i < pixels.Length; i++)
                {
                    if ((pixels[i] & unchecked((int)0xFF000000)) == 0)
                    {
                        pixels[i] = unchecked((int)0xFFFF0000);
                    }
                }
                image.SaveArgb32Pixels(rect, pixels);
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
 * 1. When you need to programmatically select multiple non‑contiguous areas of a PNG and exclude a rectangular region before applying a solid color overlay.
 * 2. When you want to replace all fully transparent pixels in an image with a specific opaque color such as red for printing or branding purposes.
 * 3. When you are building an automated image‑pre‑processing pipeline that must isolate complex shapes using Magic Wand thresholds and then mask out unwanted sections.
 * 4. When you need to generate a new PNG file where the background is removed and filled with a uniform color to meet UI design guidelines.
 * 5. When you are creating a batch tool that applies custom selections and color fills to a set of images without manual Photoshop editing.
 */
