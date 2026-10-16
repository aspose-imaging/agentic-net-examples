// HOW-TO: Convert ODG to 8‑Bit BMP with Reduced File Size in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (BmpOptions options = new BmpOptions())
            {
                options.BitsPerPixel = 8;
                image.Save(outputPath, options);
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
 * 1. When you need to display OpenDocument graphics on a legacy Windows application that only supports 8‑bit BMP files.
 * 2. When you want to reduce the storage footprint of ODG drawings by converting them to a compressed 256‑color BMP for batch processing.
 * 3. When an automated pipeline must convert user‑uploaded ODG diagrams to BMP thumbnails that can be rendered by low‑memory devices.
 * 4. When integrating Aspose.Imaging in a C# service that prepares printable assets by turning ODG files into BMP format with a limited palette.
 * 5. When migrating archival ODG artwork to a format compatible with older image viewers while keeping file sizes small.
 */
