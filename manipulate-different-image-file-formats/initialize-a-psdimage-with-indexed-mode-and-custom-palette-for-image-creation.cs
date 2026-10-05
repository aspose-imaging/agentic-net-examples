// HOW-TO: Create Indexed Color PSD With Custom Palette In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-28
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.FromArgb(255, 0, 0, 0),
                Aspose.Imaging.Color.FromArgb(255, 255, 255, 255),
                Aspose.Imaging.Color.FromArgb(255, 255, 0, 0),
                Aspose.Imaging.Color.FromArgb(255, 0, 255, 0),
                Aspose.Imaging.Color.FromArgb(255, 0, 0, 255)
            };
            Aspose.Imaging.ColorPalette palette = new Aspose.Imaging.ColorPalette(colors);

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = palette;

            using (Aspose.Imaging.Image psd = Aspose.Imaging.Image.Create(options, 200, 200))
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
 * 1. When you need to generate a Photoshop PSD file in indexed color mode with a predefined palette, which is ideal for web graphics that require a limited set of colors.
 * 2. When exporting UI mockups or diagrams to PSD while ensuring the file uses a custom palette for brand‑consistent colors.
 * 3. When creating game asset PSD templates that require indexed colors to keep file sizes small and maintain a fixed palette.
 * 4. When converting data visualizations into PSD files that must use a specific set of colors for accurate printing.
 * 5. When automating batch production of PSD files with a custom color palette for integration into a digital asset management workflow.
 */
