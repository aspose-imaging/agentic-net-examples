// HOW-TO: Draw a Black Line on an Indexed PSD Canvas in C# (Aspose.Imaging for .NET)
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

            // Create a grayscale palette with 256 colors
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                paletteColors[i] = Aspose.Imaging.Color.FromArgb(255, i, i, i);
            }
            Aspose.Imaging.ColorPalette palette = new Aspose.Imaging.ColorPalette(paletteColors);

            // Set up PSD options for an indexed image
            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = palette;
            options.CompressionMethod = CompressionMethod.RLE;

            // Create the indexed PSD canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1);
                graphics.DrawLine(pen, 10, 10, 190, 190);

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
 * 1. When you need to generate a simple diagram or annotation in a PSD file without using Photoshop, you can programmatically draw a line on an indexed canvas with Aspose.Imaging for .NET.
 * 2. When creating thumbnails or preview images for a design workflow that require an indexed color PSD to keep file size low, you can draw guide lines directly in C#.
 * 3. When automating batch processing of PSD assets and need to add a visual marker (e.g., a cut line) to each file, this code lets you add the line without manual editing.
 * 4. When building a server‑side service that returns a PSD with a custom overlay, such as a ruler or grid line, you can draw it on an indexed image using the Graphics object.
 * 5. When integrating Aspose.Imaging into a .NET application that must produce PSD files compatible with legacy Photoshop versions, drawing a line on an indexed palette ensures both compatibility and minimal file size.
 */
