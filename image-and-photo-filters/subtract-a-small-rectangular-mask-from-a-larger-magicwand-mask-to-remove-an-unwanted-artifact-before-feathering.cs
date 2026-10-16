// HOW-TO: Subtract a Rectangle Mask from Magic Wand Selection and Feather in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output\\result.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                        .Subtract(new RectangleMask(50, 50, 20, 20))
                        .GetFeathered(new FeatheringSettings() { Size = 5 })
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove a small unwanted object from a photo by subtracting a rectangular region from a Magic Wand selection before applying a soft edge feather in C#.
 * 2. When preparing product images for e‑commerce, you can eliminate background artifacts by masking them out and feathering the edges, then saving the result as a PNG with transparency.
 * 3. When cleaning scanned documents, you can subtract a rectangular mask that covers a stamp or blemish from the auto‑selected area and feather the border to blend it seamlessly.
 * 4. When creating composite graphics, you can use the Magic Wand tool to select a region, subtract a specific rectangle to exclude a logo, feather the cutout, and export to a PNG with alpha channel.
 * 5. When automating photo retouching in a batch process, you can programmatically remove a known rectangular defect from each image, feather the selection for smooth transition, and store the output as a lossless PNG.
 */
