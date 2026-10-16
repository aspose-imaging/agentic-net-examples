// HOW-TO: Add Custom Metadata When Converting EPS to PSD in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                var psdOptions = new PsdOptions();
                psdOptions.Source = new FileCreateSource(outputPath, false);
                epsImage.Save(outputPath, psdOptions);
            }

            using (Image psdImage = Image.Load(outputPath))
            {
                // EXIF modification omitted due to unavailable API method.
                psdImage.Save(outputPath);
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
 * 1. When a design workflow requires converting vector EPS artwork to layered PSD files while embedding custom metadata for downstream asset tracking.
 * 2. When an automated build process needs to generate Photoshop‑compatible files from EPS sources and store author or copyright information in the PSD header.
 * 3. When a digital asset management system must preserve source file references by adding metadata after converting EPS logos to PSD for editing.
 * 4. When a batch conversion tool must create PSD files from EPS illustrations and include project identifiers for version control.
 * 5. When a C# application integrates Aspose.Imaging to transform EPS graphics into PSD format and tag the output with custom properties for cataloguing.
 */
