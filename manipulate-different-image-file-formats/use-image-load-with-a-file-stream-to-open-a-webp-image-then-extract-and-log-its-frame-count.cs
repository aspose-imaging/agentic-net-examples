// HOW-TO: Load WebP Image From Stream And Get Frame Count In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Image image = Image.Load(fs))
                {
                    int frameCount = 1;
                    if (image is IMultipageImage multipage)
                    {
                        frameCount = multipage.PageCount;
                    }

                    Console.WriteLine($"Frame count: {frameCount}");
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
 * 1. When you need to determine the number of frames in an animated WebP file by loading it from a FileStream.
 * 2. When you want to read a WebP image using a stream to minimize memory usage while extracting its page count.
 * 3. When building a logging or reporting utility that records the frame count of each WebP image processed.
 * 4. When you must differentiate between single‑frame and multi‑page WebP images to apply separate processing logic.
 * 5. When debugging image import issues by printing the detected frame count to the console for verification.
 */
