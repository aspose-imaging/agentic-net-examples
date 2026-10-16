// HOW-TO: Convert CDR to PNG with Maximum Compression Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string inputPath = Path.Combine(inputDirectory, "sample.cdr");
            string outputPath = Path.Combine(outputDirectory, "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    Source = new FileCreateSource(outputPath, false)
                };

                cdrImage.Save(outputPath, pngOptions);
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
 * 1. When a graphics workflow needs to archive CorelDRAW designs as small PNG files for web delivery, this code converts the CDR to a highly compressed PNG in C#.
 * 2. When an automated batch process must generate thumbnail previews of CDR drawings while minimizing storage size, the example shows how to load the CDR and save a compressed PNG using Aspose.Imaging.
 * 3. When a .NET application has to export vector artwork from CorelDRAW to a raster format compatible with browsers, the code demonstrates the conversion with maximum ZIP compression.
 * 4. When a server‑side service needs to receive user‑uploaded CDR files and store them as optimized PNGs to reduce bandwidth, this snippet provides the necessary steps in C#.
 * 5. When a developer wants to integrate CorelDRAW to PNG conversion into a CI/CD pipeline and ensure the output images are as small as possible, the example illustrates setting the PngCompressionLevel to ZipLevel9 with Aspose.Imaging.
 */
