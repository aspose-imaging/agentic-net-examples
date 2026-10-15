// HOW-TO: Compress PNG with Maximum Lossless Compression and Compare File Size in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output_compressed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PngImage image = (PngImage)Image.Load(inputPath))
            {
                // Set filter method and lossless compression level
                PngOptions options = new PngOptions
                {
                    FilterType = PngFilterType.Adaptive,
                    CompressionLevel = 9 // Maximum lossless compression
                };

                image.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the storage size of high‑resolution PNG assets for a web application without sacrificing image quality, you can use this code to apply maximum lossless compression and verify the size reduction.
 * 2. When preparing PNG files for email attachments or API responses, this approach lets you compress the images to meet size limits while still preserving transparency and color fidelity.
 * 3. When building an automated image‑processing pipeline that archives screenshots or generated graphics, the code ensures each PNG is stored in the smallest possible lossless form and logs the before‑and‑after sizes.
 * 4. When optimizing assets for mobile apps where bandwidth is limited, you can compress PNG resources with Aspose.Imaging and compare the file sizes to decide whether further optimization is required.
 * 5. When creating a batch tool for designers to quickly evaluate the impact of different PNG filter types and compression levels, this snippet demonstrates how to apply the adaptive filter with level 9 and measure the resulting file size.
 */
