// HOW-TO: Batch Convert EMF Files to SVG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;

namespace EmfToSvgBatch
{
    class Program
    {
        static void Main()
        {
            string inputDirectory = "InputEmf";
            string outputDirectory = "OutputSvg";

            try
            {
                if (!Directory.Exists(inputDirectory))
                {
                    Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                    return;
                }

                string[] emfFiles = Directory.GetFiles(inputDirectory, "*.emf");
                foreach (string inputPath in emfFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (EmfImage image = (EmfImage)Image.Load(inputPath))
                    {
                        image.Save(outputPath, new SvgOptions());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a library of legacy EMF icons to scalable SVG format for modern web applications.
 * 2. When generating vector graphics for PDF reports and want to ensure the images remain resolution‑independent by converting EMF to SVG in bulk.
 * 3. When automating the preparation of design assets for a responsive UI, converting multiple EMF drawings to SVG without losing vector fidelity.
 * 4. When integrating a CI/CD pipeline that must transform EMF diagrams into SVG for documentation sites automatically.
 * 5. When creating a batch conversion tool to process user‑uploaded EMF files and store them as SVG for cross‑platform viewing.
 */
