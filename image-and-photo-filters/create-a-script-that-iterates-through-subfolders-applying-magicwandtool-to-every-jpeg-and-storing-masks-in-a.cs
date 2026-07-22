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
            string inputRoot = "Input";
            string outputRoot = "Masks";

            if (!Directory.Exists(inputRoot))
            {
                Directory.CreateDirectory(inputRoot);
                Console.WriteLine($"Input directory created at: {inputRoot}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputRoot);

            string[] files = Directory.GetFiles(inputRoot, "*.jpg", SearchOption.AllDirectories);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string relativePath = Path.GetRelativePath(inputRoot, inputPath);
                string outputPath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".png"));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool
                        .Select(image, new MagicWandSettings(0, 0))
                        .Apply();

                    image.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
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
 * 1. When a developer needs to automatically generate transparent PNG masks for every JPEG photo in a nested folder structure, such as preparing assets for a web‑based image editor.
 * 2. When a batch image‑processing pipeline must isolate foreground objects in JPEGs using Aspose.Imaging’s MagicWandTool and store the resulting masks for later compositing.
 * 3. When a content‑management system requires pre‑computed selection masks for uploaded JPEG images to speed up on‑the‑fly cropping or background removal.
 * 4. When a machine‑learning workflow needs consistent PNG alpha masks derived from a large collection of JPEG training images stored across multiple subdirectories.
 * 5. When an e‑commerce platform wants to create transparent PNG overlays for product photos located in various category folders without manual intervention.
 */