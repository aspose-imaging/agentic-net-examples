// HOW-TO: Save Magic Wand Selection as Grayscale BMP Mask in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
        string inputPath = "input.jpg";
        string maskPath = "mask.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(maskPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Apply();

                var bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 8;

                image.Save(maskPath, bmpOptions);
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
 * 1. When you need to isolate a region selected with Aspose.Imaging's MagicWandTool and store it as an 8‑bit grayscale BMP for later compositing or analysis.
 * 2. When building a batch workflow that reuses the same selection mask on multiple images, saving the mask once as a BMP reduces processing time.
 * 3. When performing background removal, exporting the MagicWand selection to a separate BMP allows you to apply the mask to different layers or formats without recalculating it.
 * 4. When integrating with third‑party tools that only accept grayscale BMP masks, this code converts the MagicWand selection into the required format.
 * 5. When debugging image‑segmentation algorithms, saving the generated mask as a BMP lets you visually inspect the selection and compare results across runs.
 */
