using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

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
                    .Union(new RectangleMask(200, 200, 150, 100))
                    .Apply();

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
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
 * 1. When a developer needs to automatically select a region of similar color in a PNG image using a Magic Wand tool and then expand the selection with a custom rectangular polygon to create a composite mask for further editing.
 * 2. When an application must combine a content‑aware selection (Magic Wand) with a manually defined rectangle to isolate both irregular and precise areas before exporting the result as a true‑color PNG with alpha channel.
 * 3. When a photo‑processing workflow requires merging a dynamic, tolerance‑based selection with a fixed geometric shape to generate a single mask that can be saved as a PNG file for downstream compositing.
 * 4. When a developer wants to programmatically create a combined selection in C# by uniting a Magic Wand mask with a rectangle mask to protect or modify specific parts of an image while preserving transparency.
 * 5. When building an image‑annotation tool that needs to let users select complex regions using Magic Wand and then add a rectangular region, merging them via Union before saving the final selection as a PNG with alpha support.
 */