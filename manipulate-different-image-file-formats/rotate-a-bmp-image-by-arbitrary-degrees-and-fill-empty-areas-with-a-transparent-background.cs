// HOW-TO: Rotate BMP Image by Arbitrary Degrees with Transparent Background in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                float angle = 45f; // arbitrary rotation angle
                Aspose.Imaging.Color transparent = Aspose.Imaging.Color.FromArgb(0, 0, 0, 0);
                image.Rotate(angle, true, transparent);

                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When you need to rotate a legacy BMP graphic for a UI element while keeping the corners transparent so it blends with any background.
 * 2. When generating game assets that require a BMP sprite to be turned at custom angles and the empty space must remain see‑through.
 * 3. When processing scanned documents stored as BMP files and you must tilt‑correct them without adding a solid background color.
 * 4. When creating dynamic thumbnails for a Windows desktop application and the rotated BMP must retain transparency for overlay effects.
 * 5. When automating batch image preparation for printing where BMP files are rotated to specific angles and the surrounding area must stay transparent for later compositing.
 */
