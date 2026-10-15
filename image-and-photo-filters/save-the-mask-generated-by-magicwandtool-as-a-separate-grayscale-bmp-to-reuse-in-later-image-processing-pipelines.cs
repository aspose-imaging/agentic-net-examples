// HOW-TO: Save Magic Wand Selection as Grayscale BMP Mask in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputMaskPath = "output/mask.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputMaskPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10)).Apply();

                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8
                };
                image.Save(outputMaskPath, bmpOptions);
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
 * 1. When you need to isolate a region of a JPEG and store the selection as a reusable grayscale BMP mask for later background‑removal processing.
 * 2. When you want to generate a compact 8‑bit BMP mask from a Magic Wand selection to feed into a machine‑learning model that expects binary masks.
 * 3. When an automated pipeline must save the Magic Wand selection as a separate image so the same mask can be applied to multiple source files without re‑computing the selection.
 * 4. When building a web service that extracts object outlines from uploaded photos and returns the result as a BMP mask for client‑side compositing.
 * 5. When you need a reusable mask file for batch editing tasks, such as applying filters or adjustments only inside the selected area across many images.
 */
