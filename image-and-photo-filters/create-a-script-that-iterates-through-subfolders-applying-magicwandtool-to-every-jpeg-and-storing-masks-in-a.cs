// HOW-TO: Batch Apply Magic Wand Selection to JPEGs and Save PNG Masks in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(outputRoot);

            string[] files = Directory.GetFiles(inputRoot, "*.*", SearchOption.AllDirectories);
            foreach (string inputPath in files)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                {
                    continue;
                }

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
                    int pointX = image.Width / 2;
                    int pointY = image.Height / 2;

                    MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY))
                        .Apply();

                    PngOptions pngOptions = new PngOptions
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
 * 1. When you need to automatically generate transparent PNG masks for every JPEG photo in a nested folder structure for later compositing or analysis.
 * 2. When a batch image‑processing pipeline must isolate the central region of each JPEG using Aspose.Imaging’s MagicWandTool before exporting the selection as an alpha‑channel PNG.
 * 3. When you want to create a searchable archive of mask images that mirrors the original directory hierarchy, preserving relative paths while converting formats.
 * 4. When a desktop application must process user‑uploaded photo collections, apply a magic‑wand selection to each file, and store the results without overwriting the source images.
 * 5. When you are building a preprocessing step for machine‑learning models that requires PNG masks with true‑color and alpha channels derived from JPEG inputs across multiple subfolders.
 */
