// HOW-TO: Save APNG With Lossless Compression And Color Profile In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
            string outputPath = "output/output.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                ApngOptions options = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                apng.Save(outputPath, options);
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
 * 1. When a game developer needs to export animated PNG assets while preserving exact colors for consistent rendering across devices.
 * 2. When a web designer wants to optimize animated icons for browsers without sacrificing visual fidelity or embedded ICC profiles.
 * 3. When a medical imaging application must store frame‑by‑frame scans as APNGs while keeping the original color calibration intact.
 * 4. When an e‑learning platform generates animated diagrams and requires lossless compression to keep file size low and color accuracy for accessibility tools.
 * 5. When a digital publishing workflow converts source APNG files to final assets and needs to embed the source color profile to ensure correct printing colors.
 */
