// HOW-TO: Apply Union Subtract and Feathered Mask to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

namespace MyMaskingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.png";
            string outputPath = "output\\masked.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            try
            {
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                        .Union(new MagicWandSettings(20, 20))
                        .Subtract(new RectangleMask(30, 30, 50, 50))
                        .GetFeathered(new FeatheringSettings() { Size = 5 })
                        .Apply();

                    image.Save(outputPath);
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
 * 1. When you need to merge two magic‑wand selections and then cut out a rectangular portion before softening the edges of a PNG file in a C# application.
 * 2. When you want to programmatically create a composite mask that removes unwanted background areas and applies a feathered border to improve visual blending.
 * 3. When building a reusable .NET library that performs common mask operations such as union, subtraction, and feathering for batch image processing pipelines.
 * 4. When automating preparation of product photos by selecting regions, excluding logo areas, and adding a subtle feathered transition to maintain a professional look.
 * 5. When integrating Aspose.Imaging’s MagicWandTool into a C# service that dynamically generates masked thumbnails with smooth edges for web thumbnails.
 */
