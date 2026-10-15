// HOW-TO: Create lossless JPEG2000 from PNG with memory buffer limit in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\source.png";
            string outputPath = "Output\\result.jp2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 10 };
            using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                int width = srcImage.Width;
                int height = srcImage.Height;

                using (Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image jp2Image = new Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Image(width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(jp2Image);
                    graphics.DrawImage(srcImage, 0, 0, width, height);

                    var options = new Jpeg2000Options();
                    jp2Image.Save(outputPath, options);
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
 * 1. When you need to convert high‑resolution PNG assets to JPEG2000 for archival while keeping the image lossless and controlling memory usage in a C# application.
 * 2. When a server‑side service must generate JPEG2000 files from user‑uploaded PNGs without exceeding a predefined buffer size to avoid out‑of‑memory errors.
 * 3. When a desktop tool processes PNG graphics and saves them as JPEG2000 for efficient storage in a medical imaging workflow that requires lossless compression.
 * 4. When an automated batch job creates JPEG2000 thumbnails from PNG source files while ensuring the conversion runs within limited RAM on a Windows service.
 * 5. When integrating Aspose.Imaging into a .NET microservice that receives PNG streams and returns JPEG2000 responses, and you must enforce a buffer hint to keep the service responsive.
 */
