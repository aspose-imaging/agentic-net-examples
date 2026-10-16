// HOW-TO: Convert Multiple WMF Files to JPEG in Parallel with C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WmfToJpegParallel
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputWmf";
                string outputDirectory = @"C:\OutputJpeg";

                // Get all WMF files in the input directory
                string[] wmfFiles = Directory.GetFiles(inputDirectory, "*.wmf");

                Parallel.ForEach(wmfFiles, wmfPath =>
                {
                    // Verify input file exists
                    if (!File.Exists(wmfPath))
                    {
                        Console.Error.WriteLine($"File not found: {wmfPath}");
                        return;
                    }

                    // Determine output file path
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(wmfPath) + ".jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load WMF and save as JPEG
                    using (Image image = Image.Load(wmfPath))
                    {
                        var jpegOptions = new JpegOptions();
                        image.Save(outputPath, jpegOptions);
                    }
                });
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
 * 1. When you need to batch‑convert a folder of legacy WMF drawings to JPEG images quickly for web publishing.
 * 2. When you want to speed up image conversion on a multi‑core server by processing WMF files in parallel.
 * 3. When you must generate JPEG thumbnails from vector WMF assets as part of an automated build pipeline.
 * 4. When you are migrating old Windows Metafile graphics to a modern format for a mobile app without blocking the UI thread.
 * 5. When you require a simple C# script that loads WMF files, applies default JPEG options, and saves them to a separate output directory.
 */
