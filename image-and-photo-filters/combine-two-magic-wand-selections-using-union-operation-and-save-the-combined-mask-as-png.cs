using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

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
                    .Select(image, new MagicWandSettings(120, 100))
                    .Union(new MagicWandSettings(200, 150))
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
 * 1. When a developer needs to extract and merge two separate regions of a PNG image—such as foreground objects selected by different color tolerances—using Aspose.Imaging’s Magic Wand tool and save the combined mask as a PNG with an alpha channel.
 * 2. When building an automated image‑masking pipeline that must combine selections from two coordinates (e.g., 120,100 and 200,150) into a single transparent overlay for further compositing in C#.
 * 3. When creating a batch process that validates the existence of input files, applies a union of Magic Wand selections, and outputs a true‑color‑with‑alpha PNG for use in web graphics or UI assets.
 * 4. When implementing a feature in a .NET application that lets users click two points on a raster image to select areas, merges those selections, and stores the result as a lossless PNG for later editing.
 * 5. When needing to programmatically generate a combined selection mask for scientific imaging or medical scans, using Aspose.Imaging’s MagicWandSettings to define tolerance and saving the mask in a PNG format that preserves transparency.
 */