// HOW-TO: Convert CDR to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                var options = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
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
 * 1. When a designer needs to embed CorelDRAW artwork into a web page without losing quality, they can convert the .cdr file to a losslessly compressed .png using C#.
 * 2. When an automated build pipeline must generate thumbnail previews of CDR assets while keeping the original dimensions, this code provides a fast conversion to PNG.
 * 3. When a digital asset management system stores vector drawings but requires raster copies for compatibility, developers can use this snippet to create exact‑size PNGs with maximum compression.
 * 4. When a batch‑processing tool has to reduce file size of CDR graphics for email distribution without sacrificing visual fidelity, the code saves them as zip‑level‑9 PNGs.
 * 5. When a Windows desktop application needs to display CorelDRAW files in a picture box control, converting them to losslessly compressed PNGs ensures accurate rendering and minimal memory usage.
 */
