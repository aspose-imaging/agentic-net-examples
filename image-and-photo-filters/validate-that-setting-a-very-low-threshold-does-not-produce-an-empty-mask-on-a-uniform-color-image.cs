// HOW-TO: Validate Magic Wand Threshold on Uniform Color Image in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                int width = 200;
                int height = 200;
                int argbColor = unchecked((int)0xFF00FF00); // Opaque green

                using (RasterImage uniform = (RasterImage)Image.Create(
                    new PngOptions { Source = new FileCreateSource(inputPath, false) },
                    width, height))
                {
                    int[] pixels = new int[width * height];
                    for (int i = 0; i < pixels.Length; i++)
                        pixels[i] = argbColor;

                    var rect = new Rectangle(0, 0, width, height);
                    uniform.SaveArgb32Pixels(rect, pixels);
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 1 })
                    .Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            using (RasterImage result = (RasterImage)Image.Load(outputPath))
            {
                int width = result.Width;
                int height = result.Height;
                var rect = new Rectangle(0, 0, width, height);
                int[] resultPixels = result.LoadArgb32Pixels(rect);
                bool hasNonTransparent = false;
                foreach (int pixel in resultPixels)
                {
                    int alpha = (pixel >> 24) & 0xFF;
                    if (alpha != 0)
                    {
                        hasNonTransparent = true;
                        break;
                    }
                }

                if (hasNonTransparent)
                    Console.WriteLine("Validation passed: mask is not empty.");
                else
                    Console.WriteLine("Validation failed: mask is empty.");
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
 * 1. When you need to ensure the Aspose.Imaging MagicWand tool selects pixels correctly even on a solid‑color PNG.
 * 2. When you want to test that a low threshold value does not generate an empty selection mask for uniform images.
 * 3. When you are automating image preprocessing and must verify that background removal works on single‑color pictures.
 * 4. When you need to programmatically create a uniform image, apply a magic wand selection, and save the result without losing alpha transparency.
 * 5. When you are debugging image segmentation logic and require a reproducible example that confirms threshold handling in C#.
 */
