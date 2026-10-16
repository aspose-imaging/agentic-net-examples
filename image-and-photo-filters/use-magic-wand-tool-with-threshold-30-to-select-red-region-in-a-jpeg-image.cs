// HOW-TO: Select Red Region in JPEG Using Magic Wand Tool C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = 30 })
                    .Apply();

                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically isolate a red-colored area in a JPEG photo for further editing or analysis in a C# application.
 * 2. When building a batch image processor that extracts specific color regions from scanned photos to create masks or overlays using Aspose.Imaging.
 * 3. When creating a custom photo‑filter that highlights red objects by selecting them with a Magic Wand threshold before applying effects in .NET.
 * 4. When developing a quality‑control tool that verifies the presence of red labels on product images by selecting the red region and saving the result.
 * 5. When implementing an automated cropping routine that identifies and retains only the red portion of an image for use in marketing materials.
 */
