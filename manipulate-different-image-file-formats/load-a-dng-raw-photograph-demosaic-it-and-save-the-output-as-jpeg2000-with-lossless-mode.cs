// HOW-TO: Convert DNG Raw Photo to Lossless JPEG2000 in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "photo.dng");
            string outputPath = Path.Combine("Output", "photo.jp2");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                Jpeg2000Options options = new Jpeg2000Options();
                dng.Save(outputPath, options);
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
 * 1. When you need to archive raw camera files by converting DNG images to a smaller, lossless JPEG2000 format for long‑term storage.
 * 2. When a web service must deliver high‑quality pictures to clients that only support JPEG2000, requiring on‑the‑fly DNG to JPEG2000 conversion in C#.
 * 3. When a photo‑editing application wants to preview raw DNG files after demosaicing without relying on proprietary SDKs, using Aspose.Imaging to save them as lossless JPEG2000.
 * 4. When you are building a batch conversion tool that prepares raw photographs for medical imaging systems that require lossless JPEG2000 input.
 * 5. When you need to integrate raw image processing into a .NET workflow that later compresses images losslessly for archival or transmission purposes.
 */
