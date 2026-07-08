using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputRoot = "Input";
            string outputRoot = "Output";

            var jpegFiles = Directory.GetFiles(inputRoot, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

            foreach (var inputPath in jpegFiles)
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
                    // Apply MagicWand selection at (0,0) and apply the mask to the image
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                    // Save the masked image as PNG with alpha channel
                    var pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to batch‑remove backgrounds from a large collection of JPEG photos stored in nested directories and save the resulting transparent PNG masks for use in web galleries.
 * 2. When an e‑commerce platform wants to automatically generate product image cut‑outs by applying the MagicWand selection to every JPEG in its catalog and exporting PNG files with an alpha channel for seamless overlay.
 * 3. When a digital archivist must process scanned JPEG documents across multiple subfolders, isolate foreground elements with the MagicWandTool, and store the selections as PNG masks for later OCR or annotation.
 * 4. When a mobile app backend requires a C# routine that traverses user‑uploaded JPEG folders, applies a point‑and‑click MagicWand selection at the top‑left corner, and outputs PNG images preserving transparency for UI composition.
 * 5. When a game developer wants to convert a hierarchy of JPEG texture assets into PNG sprites with transparent backgrounds by using Aspose.Imaging’s MagicWandTool in an automated C# script.
 */