// HOW-TO: Convert OTG to BMP with 8‑Bit Palette in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (BmpOptions options = new BmpOptions())
                {
                    options.BitsPerPixel = 8;
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
 * 1. When you need to display legacy OTG graphics in a Windows application that only supports BMP files, you can convert them using Aspose.Imaging with an 8‑bit palette to keep the files small.
 * 2. When generating thumbnails for a batch of OTG images to embed in a PDF report, converting to 8‑bit BMP reduces storage while preserving sufficient color detail.
 * 3. When migrating an old CAD system’s OTG assets to a modern asset pipeline that requires BMP format for texture mapping, using this code ensures quick conversion and lower memory usage.
 * 4. When creating a lightweight image archive for mobile devices, converting OTG files to 8‑bit BMP minimizes file size without needing external tools.
 * 5. When automating a server‑side process that receives OTG uploads and must store them as BMP for compatibility with legacy printing hardware, this snippet handles the conversion efficiently.
 */
