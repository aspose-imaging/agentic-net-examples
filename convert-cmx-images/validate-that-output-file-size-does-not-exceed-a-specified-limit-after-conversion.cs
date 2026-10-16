// HOW-TO: Convert PNG to JPEG and Verify Output Size Under 5 MB in C# (Aspose.Imaging for .NET)
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

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output.jpg";
                long maxOutputSizeBytes = 5 * 1024 * 1024; // 5 MB

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
                }

                FileInfo outInfo = new FileInfo(outputPath);
                if (outInfo.Length > maxOutputSizeBytes)
                {
                    Console.Error.WriteLine($"Output file size exceeds limit: {outInfo.Length} bytes > {maxOutputSizeBytes} bytes");
                }
                else
                {
                    Console.WriteLine($"Conversion successful. Output size: {outInfo.Length} bytes");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate JPEG thumbnails from PNG assets while ensuring each file stays below a specific size limit for email attachments.
 * 2. When an e‑commerce platform must convert product PNG images to JPEG and guarantee they do not exceed the 5 MB upload restriction.
 * 3. When a mobile app prepares user‑uploaded PNG pictures for storage by converting them to JPEG and checking the file‑size constraint.
 * 4. When a batch‑processing script has to validate that converted images fit within a CDN‑imposed maximum file size.
 * 5. When a reporting tool converts high‑resolution PNG charts to JPEG and needs to confirm the output remains under a defined byte limit.
 */
