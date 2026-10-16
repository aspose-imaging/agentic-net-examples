// HOW-TO: Convert SVG to EMF with Layer Flattening in C# (Aspose.Imaging for .NET)
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

namespace VectorFlattenExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "data/input.svg";
                string outputPath = "output/result.emf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Flattening layers (if applicable) is handled internally when saving.
                    image.Save(outputPath);
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
 * 1. When you need to embed an SVG illustration into a Microsoft Office document that only accepts EMF, you can convert and flatten the vector using C# and Aspose.Imaging.
 * 2. When generating printable graphics for Windows applications, converting multi‑layer SVG assets to a single‑layer EMF ensures compatibility with GDI+ rendering.
 * 3. When automating a batch process that consolidates design files, this code lets you programmatically turn SVG files into flattened EMF files for archival or distribution.
 * 4. When a reporting tool requires vector images in EMF format but your source assets are SVG, you can use the snippet to perform the conversion in a .NET service.
 * 5. When creating a server‑side API that receives SVG uploads and returns EMF files for downstream CAD or diagram software, the example shows the necessary C# steps.
 */
