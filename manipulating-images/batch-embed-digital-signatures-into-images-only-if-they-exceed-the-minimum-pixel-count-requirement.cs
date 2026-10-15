// HOW-TO: Batch Embed Digital Signatures Into Large Images Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats;

namespace BatchDigitalSignature
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "input";
                string outputFolder = "output";
                string password = "myPassword";

                // Ensure the output base directory exists
                Directory.CreateDirectory(outputFolder);

                var files = Directory.GetFiles(inputFolder);
                foreach (var inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (var image = (RasterImage)Image.Load(inputPath))
                    {
                        if (image.Width < 8 || image.Height < 8 || image.Width * image.Height < 16384)
                        {
                            Console.WriteLine($"Skipping {inputPath}: does not meet size requirements.");
                            continue;
                        }

                        // Embed the digital signature using the provided password
                        image.EmbedDigitalSignature(password);

                        string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        image.Save(outputPath);
                    }
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
 * 1. When you need to protect high‑resolution product photos by embedding a password‑protected digital signature before publishing them online.
 * 2. When a legal compliance system must automatically sign only images that meet a minimum pixel count to ensure traceability of large‑format documents.
 * 3. When a batch processing pipeline has to skip small thumbnails and apply a digital signature only to images larger than 16 KB of pixels.
 * 4. When you want to secure scanned engineering drawings by embedding a signature into each file that exceeds the defined size threshold.
 * 5. When an archival workflow requires adding a password‑protected signature to all qualifying JPEG or PNG files in a folder while preserving the original format.
 */
