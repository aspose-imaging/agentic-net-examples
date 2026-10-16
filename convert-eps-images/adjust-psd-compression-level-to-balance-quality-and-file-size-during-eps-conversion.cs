// HOW-TO: Convert EPS to PSD with RLE Compression to Reduce File Size in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    // Set compression method to balance quality and file size
                    options.CompressionMethod = CompressionMethod.RLE;

                    image.Save(outputPath, options);
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
 * 1. When you need to convert vector EPS artwork to a layered PSD file while keeping the file size manageable for web uploads.
 * 2. When preparing print‑ready files, you want to preserve image quality but reduce PSD storage by applying RLE compression during the EPS to PSD conversion.
 * 3. When building an automated asset pipeline that ingests EPS logos and outputs PSDs for designers, using Aspose.Imaging to balance quality and disk usage.
 * 4. When archiving legacy EPS graphics in PSD format for backup, you require a compression method that maintains fidelity without creating huge files.
 * 5. When integrating a C# application with a content‑management system, you must convert incoming EPS files to PSDs with controlled compression to meet storage quotas.
 */
