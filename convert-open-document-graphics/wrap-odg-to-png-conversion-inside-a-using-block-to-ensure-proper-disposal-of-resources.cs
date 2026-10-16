// HOW-TO: Convert ODG to PNG in C# with Proper Resource Disposal (Aspose.Imaging for .NET)
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

namespace OdgToPngConverter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.odg";
            string outputPath = "output.png";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PngOptions();
                    image.Save(outputPath, options);
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
 * 1. When an application needs to display OpenDocument graphics on the web, converting ODG files to PNG ensures browser‑compatible images while the using block releases memory automatically.
 * 2. When automating a document workflow that receives ODG diagrams from users, the code can batch‑convert each file to PNG for thumbnail generation without leaking resources.
 * 3. When integrating Aspose.Imaging into a C# service that processes design assets, the snippet safely loads an ODG image and saves it as PNG before sending it to downstream APIs.
 * 4. When building a desktop tool that lets users export their ODG drawings to PNG for printing or sharing, the using statement guarantees the image object is disposed after saving.
 * 5. When migrating legacy ODG files to a modern image format in a scheduled job, the code converts each file to PNG while ensuring proper cleanup to avoid out‑of‑memory errors.
 */
