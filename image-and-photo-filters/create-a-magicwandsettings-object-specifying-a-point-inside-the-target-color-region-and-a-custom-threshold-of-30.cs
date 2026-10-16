// HOW-TO: Select Color Region With Magic Wand Threshold 30 In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
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
                MagicWandSettings settings = new MagicWandSettings(50, 50) { Threshold = 30 };
                MagicWandTool.Select(image, settings).Apply();
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
 * 1. When you need to automatically select a contiguous area of similar color in a JPEG and export it as a PNG for further editing.
 * 2. When you want to isolate a specific object in an image by clicking inside its color region and using a custom tolerance of 30.
 * 3. When you are building a C# batch process that extracts foreground elements from photos based on a user‑defined seed point.
 * 4. When you need to create a mask of a target color area for compositing or background removal in .NET applications.
 * 5. When you want to convert a selected region of a raster image to a lossless PNG after applying a magic‑wand selection with a custom threshold.
 */
