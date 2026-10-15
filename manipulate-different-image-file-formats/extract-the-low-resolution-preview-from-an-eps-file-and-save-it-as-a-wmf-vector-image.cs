// HOW-TO: Extract Low Resolution EPS Preview and Save as WMF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

namespace EpsPreviewExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.eps";
                string outputPath = "output.wmf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    EpsImage epsImage = (EpsImage)image;
                    using (Image preview = epsImage.GetPreviewImage())
                    {
                        preview.Save(outputPath, new WmfOptions());
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
 * 1. When you need to generate a quick thumbnail of an EPS illustration for a Windows application that only supports WMF vector graphics.
 * 2. When converting legacy EPS artwork into a WMF file to embed in Office documents without rendering the full high‑resolution image.
 * 3. When creating low‑resolution previews of EPS logos for a web catalog while preserving vector scalability in WMF format.
 * 4. When automating batch processing of EPS files to extract their preview images for faster loading in a document management system.
 * 5. When integrating Aspose.Imaging in a C# service that extracts EPS previews and stores them as WMF for downstream vector‑based reporting tools.
 */
