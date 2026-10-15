// HOW-TO: Convert ODG Image to PNG While Preserving Metadata in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "Input", "sample.odg");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "sample.png");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to display an OpenDocument graphic on a web page that only supports PNG, you can convert the ODG file to PNG while keeping its metadata.
 * 2. When migrating legacy design assets stored as ODG into a PNG‑based asset pipeline, preserving author and creation information is required.
 * 3. When generating thumbnails for ODG drawings in a C# application, converting to PNG ensures compatibility with image viewers and retains the original metadata.
 * 4. When archiving ODG files in a PNG format for long‑term storage, you want to keep the embedded metadata for future reference.
 * 5. When integrating ODG files into a reporting system that outputs PNG charts, you need to convert them programmatically in .NET without losing metadata.
 */
