// HOW-TO: Batch Convert Vector Files to PDF and SVG for Archiving in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "C:\\InputVectors";
            string outputDirectory = "C:\\OutputArchive";

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    string baseName = Path.GetFileNameWithoutExtension(inputPath);

                    string pdfPath = Path.Combine(outputDirectory, baseName + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                    var pdfOptions = new PdfOptions();
                    image.Save(pdfPath, pdfOptions);

                    string svgPath = Path.Combine(outputDirectory, baseName + ".svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(svgPath));
                    var svgOptions = new SvgOptions();
                    image.Save(svgPath, svgOptions);
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
 * 1. When a company needs to preserve legacy vector artwork by converting dozens of files into PDF and SVG formats for long‑term storage.
 * 2. When an automated build pipeline must generate searchable PDF documents and scalable SVG graphics from a folder of design assets.
 * 3. When a digital asset management system requires batch export of vector drawings into web‑friendly SVG and print‑ready PDF versions.
 * 4. When a regulatory compliance process mandates archiving engineering schematics in both PDF and SVG to meet documentation standards.
 * 5. When a migration script has to transform a mixed collection of vector files into standardized formats for integration with other .NET applications.
 */
