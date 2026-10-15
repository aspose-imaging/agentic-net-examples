// HOW-TO: Extract EPS Preview Image and Save As TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\preview.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (Aspose.Imaging.Image preview = epsImage.GetPreviewImage(Aspose.Imaging.FileFormats.Eps.EpsPreviewFormat.TIFF))
                {
                    var tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                    preview.Save(outputPath, tiffOptions);
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
 * 1. When a publishing workflow needs to generate quick thumbnail previews of EPS artwork for a web gallery, this code extracts the EPS preview and saves it as a TIFF.
 * 2. When a document management system must store a low‑resolution representation of vector EPS files for faster indexing, the snippet creates a TIFF preview that can be indexed quickly.
 * 3. When an e‑commerce platform wants to display product illustrations stored as EPS but requires a raster format for compatibility with older browsers, the code converts the EPS preview to a TIFF image.
 * 4. When a batch‑processing tool needs to archive EPS files with a preview image for quality‑control checks, this example extracts the preview and writes it to a TIFF file.
 * 5. When a digital asset pipeline must generate printable low‑resolution previews of EPS logos for proofing before high‑resolution rendering, the snippet provides a TIFF preview using Aspose.Imaging in C#.
 */
