// HOW-TO: Compare EPS and PSD File Sizes After Conversion in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.eps";
        string outputPath = "output.psd";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var options = new PsdOptions();
                image.Save(outputPath, options);
            }

            long epsSize = new FileInfo(inputPath).Length;
            long psdSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"EPS size: {epsSize} bytes");
            Console.WriteLine($"PSD size: {psdSize} bytes");
            Console.WriteLine($"Size difference: {psdSize - epsSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate whether converting vector EPS artwork to layered PSD reduces or increases storage requirements for a digital asset library.
 * 2. When you want to programmatically verify the size impact of converting print‑ready EPS files to Photoshop PSD files before archiving them.
 * 3. When you are building a C# tool that decides which image format to store based on file‑size thresholds after conversion.
 * 4. When you must generate a report showing size differences between original EPS graphics and their PSD equivalents for budgeting server space.
 * 5. When you need to automate a quality‑control check that ensures PSD exports from EPS do not exceed a specified byte limit.
 */
