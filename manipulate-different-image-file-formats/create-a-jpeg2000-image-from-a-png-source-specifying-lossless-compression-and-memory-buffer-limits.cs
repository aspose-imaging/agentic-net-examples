// HOW-TO: Convert PNG to JPEG2000 With Buffer Size Hint in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\source.png";
        string outputPath = "Output\\result.jp2";

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
                using (Jpeg2000Options options = new Jpeg2000Options())
                {
                    options.BufferSizeHint = 10; // Buffer size in MB
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
 * 1. When you need to archive high‑resolution PNG graphics as lossless JPEG2000 files while controlling memory usage in a C# application.
 * 2. When a server‑side image‑processing service must convert user‑uploaded PNGs to JPEG2000 for efficient storage without sacrificing quality.
 * 3. When a desktop utility processes large PNG maps and must limit RAM consumption by setting a buffer size hint during conversion to JPEG2000.
 * 4. When integrating Aspose.Imaging into a .NET workflow that requires converting PNG assets to JPEG2000 for compatibility with legacy imaging systems.
 * 5. When building a batch conversion tool that transforms PNG screenshots into JPEG2000 format with predictable memory footprints in C#.
 */
