// HOW-TO: Convert Single‑Page CDR to Layered PSD in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var psdOptions = new PsdOptions())
                {
                    psdOptions.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    };
                    image.Save(outputPath, psdOptions);
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
 * 1. When a design workflow requires converting a CorelDRAW CDR file into a Photoshop PSD while keeping each vector object on its own layer for further editing in C#.
 * 2. When an automated build process needs to generate layered PSD assets from single‑page CDR source files using Aspose.Imaging in a .NET application.
 * 3. When a web service must accept user‑uploaded CDR graphics and return a PSD that preserves the original layers for downstream compositing.
 * 4. When migrating legacy CorelDRAW artwork to a Photoshop‑based pipeline and you need a programmatic way to retain layer structure in C#.
 * 5. When creating a batch conversion tool that transforms multiple single‑page CDR files into PSDs with separate layers for use in digital publishing.
 */
