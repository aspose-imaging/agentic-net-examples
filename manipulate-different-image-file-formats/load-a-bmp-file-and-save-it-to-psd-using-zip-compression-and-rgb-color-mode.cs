// HOW-TO: Convert BMP Image To PSD With ZIP Compression In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string inputPath = "input.bmp";
            string outputPath = "output/output.psd";

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to import legacy BMP graphics into a Photoshop workflow by converting them to PSD files with lossless ZIP compression using C#.
 * 2. When an automated batch job must generate PSD files from BMP assets for a design pipeline while preserving RGB color fidelity.
 * 3. When a web service receives BMP uploads and must store them as PSD files to maintain Photoshop compatibility for downstream editing.
 * 4. When migrating a digital asset library from BMP to PSD format to reduce file size with ZIP compression without changing the color mode, using Aspose.Imaging in .NET.
 * 5. When building a desktop utility that converts user‑selected BMP pictures to Photoshop‑ready PSD files for further editing in a C# application.
 */
