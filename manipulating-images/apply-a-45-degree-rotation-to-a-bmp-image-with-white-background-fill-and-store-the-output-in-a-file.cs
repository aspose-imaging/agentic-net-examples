// HOW-TO: Rotate BMP Image 45 Degrees With White Background In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Rotate(45f, true, Color.White);

                Source src = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = src };
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
 * 1. When you need to display a scanned document at an angle, you can rotate a BMP file 45 degrees and fill empty corners with white using Aspose.Imaging in C#.
 * 2. When preparing assets for a game that requires rotated sprite sheets, this code rotates BMP images and preserves a white background to avoid transparent artifacts.
 * 3. When converting legacy BMP graphics for a web carousel that expects a tilted orientation, you can apply a 45‑degree rotation with a white fill and save the result.
 * 4. When automating batch processing of engineering diagrams that must be rotated for printing, the snippet rotates each BMP and ensures the background stays white.
 * 5. When generating printable reports that include rotated BMP charts, this method rotates the image and fills the background with white to maintain a clean page layout.
 */
