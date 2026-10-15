// HOW-TO: Convert CorelDRAW CDR to GIF with 256‑Color Limit in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifOptions options = new GifOptions();
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
 * 1. When a desktop publishing workflow needs to generate web‑ready static or animated GIFs from legacy CorelDRAW CDR files using C#.
 * 2. When an e‑commerce platform must display product illustrations as 256‑color GIFs to reduce page load time while preserving original vector designs.
 * 3. When a marketing automation script converts designer‑provided CDR assets into GIFs for email newsletters that only support 256‑color images.
 * 4. When a migration tool processes a batch of old CorelDRAW files and saves them as GIFs for archival in a format compatible with legacy browsers.
 * 5. When a Windows service automatically creates thumbnail previews in GIF format from user‑uploaded CDR files for a document management system.
 */
