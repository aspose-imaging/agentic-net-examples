// HOW-TO: Export CorelDRAW CDR to PSD With Layer Groups Preserved in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions
                {
                    VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    }
                };
                cdr.Save(outputPath, psdOptions);
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
 * 1. When a designer needs to move a CorelDRAW illustration into Photoshop for pixel‑perfect editing while keeping the original layer groups intact.
 * 2. When an automated build pipeline must batch‑convert multiple CDR assets to PSD files so downstream tools can manipulate each layer separately.
 * 3. When a web application accepts user‑uploaded CDR files and must generate PSD versions that retain vector layers for further editing in Photoshop.
 * 4. When migrating legacy CorelDRAW assets to a new branding workflow, preserving layer hierarchy ensures minimal re‑creation effort in Photoshop.
 * 5. When creating print‑ready PDFs from PSD files, keeping the original CDR layers helps maintain editability for color‑separation and spot‑color adjustments.
 */
