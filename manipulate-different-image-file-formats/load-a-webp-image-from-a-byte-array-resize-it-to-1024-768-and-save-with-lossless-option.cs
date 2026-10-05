// HOW-TO: Resize WebP Image from Byte Array to 1024x768 Losslessly in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (Image image = Image.Load(ms))
                {
                    image.Resize(1024, 768);
                    WebPOptions options = new WebPOptions();
                    options.Lossless = true;
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
 * 1. When you receive a WebP file as a byte stream from a web service and need to create a smaller, lossless version for thumbnails in a .NET application.
 * 2. When you must resize uploaded WebP images to a standard 1024 × 768 resolution before storing them in a content‑delivery network while preserving exact pixel data.
 * 3. When a desktop utility processes images stored in memory and must output a lossless WebP file that matches a fixed size for printing or archival purposes.
 * 4. When an API endpoint accepts image data as a byte array and you need to convert it to a resized, lossless WebP format for consistent display across browsers.
 * 5. When you are building a batch conversion tool that reads WebP files into memory, resizes them to 1024 × 768, and saves them losslessly to reduce storage while keeping original quality.
 */
