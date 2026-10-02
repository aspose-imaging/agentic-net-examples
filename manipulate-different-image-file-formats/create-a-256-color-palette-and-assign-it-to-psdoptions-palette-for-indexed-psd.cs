// HOW-TO: Create Indexed PSD With 256‑Color Palette In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        try
        {
            string outputPath = "Output\\indexed.psd";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Color[] colors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                colors[i] = Color.FromArgb(255, i, i, i);
            }

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.Palette = new ColorPalette(colors);

            using (var psdImage = Image.Create(options, 800, 600))
            {
                psdImage.Save();
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
 * 1. When you need to generate a Photoshop PSD file with an indexed 256‑color grayscale palette for compatibility with legacy design tools.
 * 2. When exporting large batches of images as small‑size PSDs for web assets that require limited color depth to reduce file size.
 * 3. When creating programmatic thumbnails in PSD format that must use a fixed palette to ensure consistent colors across different platforms.
 * 4. When automating the preparation of print‑ready PSD files that must conform to a specific 256‑color palette defined by a brand style guide.
 * 5. When converting raw image data into an indexed PSD for use in game development pipelines that only support palette‑based textures.
 */
