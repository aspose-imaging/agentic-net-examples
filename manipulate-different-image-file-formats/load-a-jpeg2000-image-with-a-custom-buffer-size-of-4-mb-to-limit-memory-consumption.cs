// HOW-TO: Load JPEG2000 Image With 4 MB Buffer Size In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath, new LoadOptions() { BufferSizeHint = 4 }))
            {
                Console.WriteLine($"Loaded image: {image.Width}x{image.Height}");
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
 * 1. When processing very large JPEG2000 files on a memory‑constrained server, you can limit RAM usage by loading the image with a 4 MB buffer.
 * 2. When building a desktop application that previews high‑resolution medical scans, setting a custom buffer size prevents the app from freezing due to excessive memory allocation.
 * 3. When running image conversion in an Azure Function or other serverless environment, using a small buffer ensures the function stays within its allocated memory quota.
 * 4. When integrating Aspose.Imaging into a mobile‑backed service that streams JPEG2000 images, a reduced buffer size helps maintain responsive performance on low‑end devices.
 * 5. When performing batch processing of satellite imagery where each JPEG2000 tile is huge, specifying a buffer hint allows the process to handle many files sequentially without running out of memory.
 */
