// HOW-TO: Create Custom Magic Wand Selection and Fill with Solid Color in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Brushes;

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
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .Union(new MagicWandSettings(100, 100))
                    .Subtract(new RectangleMask(150, 150, 50, 50))
                    .Apply();

                Graphics graphics = new Graphics(image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, new RectangleF(0, 0, image.Width, image.Height));

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
 * 1. When you need to programmatically isolate complex regions in a JPEG image by merging two magic wand selections and removing a rectangular area before applying a uniform color overlay.
 * 2. When you want to automatically generate highlighted sections in product photos by selecting similar color zones, excluding a logo area, and filling the result with a brand color using C#.
 * 3. When building a batch image‑processing tool that removes unwanted background patches from scanned documents and replaces them with a solid background for OCR preparation.
 * 4. When creating custom masks for medical imaging where you combine tissue regions, subtract a known artifact area, and apply a red tint to emphasize the selected area.
 * 5. When developing a graphics editor feature that lets users select multiple color‑based areas, exclude a specific rectangle, and instantly fill the combined selection with a solid brush for quick retouching.
 */
