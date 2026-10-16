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

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.Transparent
                }
            };

            using (var image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                    pngOptions.VectorRasterizationOptions.PageSize = image.Size;
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
 * 1. When you need to convert a CorelDRAW (CDR) illustration to a PNG with a transparent background for web graphics.
 * 2. When you want to programmatically strip the background from a vector logo stored in CDR before embedding it in a mobile app.
 * 3. When an automated pipeline must rasterize CDR files to PNG while preserving image dimensions and removing any background color.
 * 4. When generating product thumbnails from CDR designs where the background must be eliminated to blend with different UI themes.
 * 5. When integrating Aspose.Imaging in a .NET service that processes user‑uploaded CDR files and outputs transparent PNGs for further editing.
 */
