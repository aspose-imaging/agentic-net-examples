// HOW-TO: Convert Single Page CDR To Transparent PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                cdr.Save(outputPath, options);
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
 * 1. When you need to export a CorelDRAW (CDR) illustration to a PNG file while keeping its alpha channel for web graphics in a C# application.
 * 2. When an automated workflow must convert single‑page CDR assets to transparent PNGs for inclusion in UI mockups or documentation.
 * 3. When a batch process generates PNG previews of CDR designs for e‑commerce product listings without losing background transparency.
 * 4. When a desktop tool needs to load a CDR file, preserve its vector transparency, and save it as a raster PNG for further image processing in .NET.
 * 5. When integrating Aspose.Imaging into a C# service that converts client‑uploaded CDR files to PNGs for thumbnail generation while maintaining transparent backgrounds.
 */
