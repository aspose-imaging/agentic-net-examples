// HOW-TO: Save PNG As BMP To MemoryStream Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
        try
        {
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "converted.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(ms, bmpOptions);
                    // Further in‑memory processing can be done with the MemoryStream here.
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
 * 1. When you need to convert a user‑uploaded PNG to BMP for a legacy system without creating a temporary file on disk.
 * 2. When you want to apply additional image processing or filters directly on the BMP data held in a MemoryStream.
 * 3. When you must send BMP image bytes over a network or API call that expects a stream rather than a file path.
 * 4. When you are generating on‑the‑fly thumbnails and require the BMP image as an in‑memory byte array for further manipulation.
 * 5. When your application runs in a sandboxed or cloud environment where disk I/O is restricted, so all conversion must stay in memory.
 */
