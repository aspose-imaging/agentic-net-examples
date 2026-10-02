// HOW-TO: Convert BMP to WebP with Quality 80 and Check Size Reduction in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.bmp";
        string outputPath = "Output/output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                using (WebPOptions options = new WebPOptions())
                {
                    options.Quality = 80;
                    image.Save(outputPath, options);
                }
            }

            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize < inputSize)
                Console.WriteLine($"Success: Output file size reduced from {inputSize} to {outputSize} bytes.");
            else
                Console.WriteLine($"Warning: Output file size not reduced (input: {inputSize}, output: {outputSize}).");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to WebP with a specific quality setting in a C# application.
 * 2. When an automated build pipeline must generate optimized WebP thumbnails from legacy BMP files while ensuring the new files are smaller than the originals.
 * 3. When a desktop utility has to batch‑process user‑uploaded BMP images to WebP at 80 % quality and report whether the conversion actually reduces disk usage.
 * 4. When you are implementing a content‑delivery service that stores images in WebP to save bandwidth and you want to verify size savings programmatically in .NET.
 * 5. When a migration script moves legacy BMP graphics to a modern WebP format and needs to log success only if the resulting file size is lower than the source.
 */
