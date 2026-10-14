// HOW-TO: Convert EPS to PSD with Custom Output Filename in C# (Aspose.Imaging for .NET)
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

namespace EpsToPsdConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = @"C:\Images\sample.eps";
                string outputPath = @"C:\Images\sample_converted.psd";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new PsdOptions();
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
 * 1. When a designer needs to programmatically convert vector EPS artwork into a Photoshop PSD file with a specific naming convention for downstream editing.
 * 2. When an automated build pipeline must generate PSD previews from EPS assets and store them in a structured folder hierarchy using custom file names.
 * 3. When a web service receives EPS uploads and must save them as PSD files with unique identifiers to avoid filename collisions.
 * 4. When a batch processing tool processes a large collection of EPS logos and saves each as a PSD using a pattern that includes the original name and a conversion suffix.
 * 5. When integrating Aspose.Imaging into a C# application to convert EPS files to PSD while ensuring the output directory is created automatically if it does not exist.
 */
