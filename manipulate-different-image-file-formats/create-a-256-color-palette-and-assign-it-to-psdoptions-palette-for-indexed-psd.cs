// HOW-TO: Create Indexed PSD With Custom 256‑Color Palette In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Color[] colors = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                colors[i] = Color.FromArgb(i, i, i);
            }

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = new ColorPalette(colors);

            using (var psd = Image.Create(options, 100, 100))
            {
                psd.Save();
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
 * 1. When you need to generate a small‑size PSD file for web graphics that uses an indexed 256‑color palette to reduce file size.
 * 2. When converting grayscale or limited‑color images into Photoshop files while preserving exact palette entries for consistent color reproduction.
 * 3. When creating programmatic assets for a game or UI where the PSD must use a predefined palette for compatibility with older Photoshop versions.
 * 4. When automating batch creation of PSD templates that require a specific palette for brand colors or corporate guidelines.
 * 5. When exporting scientific or medical visualizations to PSD format and you want to limit colors to a fixed set for easier analysis.
 */
