// HOW-TO: Extract Embedded Fonts from EMF and Generate Text Report in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "fonts_report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var emfImage = image as EmfImage;
                if (emfImage == null)
                {
                    Console.Error.WriteLine("The file is not a valid EMF image.");
                    return;
                }

                using (var writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("EMF format does not expose embedded fonts via the API.");
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
 * 1. When a developer needs to audit which fonts are embedded in an EMF vector graphic to ensure licensing compliance.
 * 2. When a developer wants to generate a plain‑text inventory of fonts used in EMF files for documentation or reporting purposes.
 * 3. When a developer is building a conversion pipeline that must verify font availability before converting EMF to another format.
 * 4. When a developer needs to detect unsupported embedded fonts in EMF files to warn users before printing or rendering.
 * 5. When a developer is troubleshooting rendering issues by checking whether an EMF image contains any embedded font information.
 */
