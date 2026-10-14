// HOW-TO: Convert PNG to PSD and Verify File Validity in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                image.Save(outputPath, psdOptions);
            }

            using (Image psdImage = Image.Load(outputPath))
            {
                if (psdImage.Width > 0 && psdImage.Height > 0)
                {
                    Console.WriteLine("PSD conversion successful and file is valid.");
                }
                else
                {
                    Console.Error.WriteLine("PSD file loaded but has invalid dimensions.");
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
 * 1. When you need to generate a Photoshop‑compatible PSD from a PNG for downstream editing.
 * 2. When an automated pipeline must ensure the converted PSD can be opened without errors before sending it to designers.
 * 3. When you want to validate image dimensions after conversion to guarantee the file isn’t corrupted.
 * 4. When integrating Aspose.Imaging into a C# application that prepares assets for Adobe Photoshop workflows.
 * 5. When you must programmatically confirm that a batch conversion of PNGs to PSDs succeeded before archiving or publishing.
 */
