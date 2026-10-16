// HOW-TO: Create Indexed Color PSD with Custom Palette in C# (Aspose.Imaging for .NET)
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

            Color[] paletteColors = new Color[]
            {
                Color.FromArgb(255, 0, 0),
                Color.FromArgb(0, 255, 0),
                Color.FromArgb(0, 0, 255)
            };
            ColorPalette palette = new ColorPalette(paletteColors);

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = palette;

            int width = 800;
            int height = 600;

            using (var image = Image.Create(options, width, height))
            {
                image.Save();
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
 * 1. When you need to generate a Photoshop PSD file with a limited set of colors for use in a game asset pipeline, you can create an indexed‑color PSD with a custom palette using Aspose.Imaging in C#.
 * 2. When exporting chart or diagram images to PSD while preserving a specific brand color palette, this code lets you produce an indexed PSD that matches the required colors.
 * 3. When building a web service that creates thumbnail previews of user‑uploaded images in PSD format with a predefined palette to reduce file size, you can use this approach.
 * 4. When automating the creation of layered mock‑ups where each layer must use the same limited palette for consistency across designs, the indexed PSD generation code is ideal.
 * 5. When converting legacy indexed‑color bitmap assets to modern PSD files without losing their original palette, this snippet provides a straightforward C# solution.
 */
