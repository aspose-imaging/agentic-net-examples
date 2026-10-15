// HOW-TO: Load JPEG2000 Image With Small Buffer And Get Dimensions In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

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

            using (Image image = Image.Load(inputPath, new LoadOptions() { BufferSizeHint = 10 }))
            {
                Console.WriteLine($"Width: {image.Width}, Height: {image.Height}");
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
 * 1. When processing large JPEG2000 files on a server with limited RAM, you can load the image using a small buffer and read its width and height.
 * 2. When building a thumbnail generator that first needs to know the original image resolution before scaling, you can quickly retrieve dimensions without loading the full image.
 * 3. When validating uploaded JP2 files in a web application, you can load them with a memory hint to ensure the file exists and extract its size for further checks.
 * 4. When creating a diagnostic tool that reports image metadata for batch‑processed JP2 assets, you can use this code to read resolution while keeping memory usage low.
 * 5. When integrating Aspose.Imaging into a mobile or IoT app where memory is constrained, you can load a JPEG2000 image with a buffer hint and display its resolution to the user.
 */
