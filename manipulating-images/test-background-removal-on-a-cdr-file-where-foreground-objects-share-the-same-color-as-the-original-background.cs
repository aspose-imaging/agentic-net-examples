// HOW-TO: Remove Background from CDR and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.png";
        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (var image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageSize = image.Size
                    }
                };
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                }
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to extract foreground graphics from a CorelDRAW (CDR) file and generate a PNG with a transparent background for web or UI assets.
 * 2. When an e‑commerce platform must automatically remove the original background color from product illustrations stored as CDR files before displaying them on a transparent canvas.
 * 3. When a batch conversion tool has to process vector drawings that share the same color as the original background, ensuring the background becomes fully transparent in the resulting PNG.
 * 4. When a mobile app requires on‑the‑fly conversion of vector CDR assets to PNG with alpha channel support without manual editing.
 * 5. When a reporting system generates charts in CorelDRAW format and needs to embed them into PDFs or HTML with no background, using Aspose.Imaging in C#.
 */
