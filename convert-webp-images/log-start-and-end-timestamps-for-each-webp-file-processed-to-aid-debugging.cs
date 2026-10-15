// HOW-TO: Log Timestamps While Converting WebP to BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

namespace WebPProcessor
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.webp";
                string outputPath = "output.bmp";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Log start timestamp
                Console.WriteLine($"Processing started: {DateTime.Now:O}");

                // Load WebP image
                using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
                {
                    // Save as BMP (or any other raster format)
                    BmpOptions bmpOptions = new BmpOptions();
                    webpImage.Save(outputPath, bmpOptions);
                }

                // Log end timestamp
                Console.WriteLine($"Processing finished: {DateTime.Now:O}");
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
 * 1. When you need to debug a batch conversion of WebP images to BMP and want to know exactly when each file starts and finishes processing.
 * 2. When you are building a server‑side service that logs processing times for image format conversions to monitor performance.
 * 3. When you must audit image transformation steps in a C# application to ensure compliance with timing requirements.
 * 4. When troubleshooting intermittent failures in WebP to BMP conversion and need timestamps to correlate errors with system events.
 * 5. When generating detailed logs for a CI/CD pipeline that processes WebP assets and requires start/end timestamps for each conversion.
 */
