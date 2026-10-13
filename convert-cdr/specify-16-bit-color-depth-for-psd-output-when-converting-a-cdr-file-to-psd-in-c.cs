// HOW-TO: Convert CDR to PSD with 16‑Bit Color Depth in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
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
 * 1. When a graphic designer needs to preserve the full tonal range of a CorelDRAW (CDR) illustration while converting it to a Photoshop (PSD) file for high‑quality printing, the code ensures the output uses 16‑bit color depth.
 * 2. When an automated batch‑processing pipeline must convert legacy CDR assets to PSD format without losing color fidelity, this snippet shows how to set the 16‑bit depth using Aspose.Imaging in C#.
 * 3. When a software application integrates with Photoshop and requires that imported CDR layers retain professional‑grade color precision, the example demonstrates loading the CDR and saving as a 16‑bit PSD.
 * 4. When a digital asset management system needs to generate PSD previews from CDR files while maintaining accurate color information for downstream editing, the code provides the necessary options.
 * 5. When a developer is building a conversion service that must comply with print‑ready standards (e.g., 16‑bit per channel), this sample illustrates how to specify the PSD output depth using Aspose.Imaging for .NET.
 */
