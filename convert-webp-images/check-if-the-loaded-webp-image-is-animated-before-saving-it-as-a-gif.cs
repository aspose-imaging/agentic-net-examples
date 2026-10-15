// HOW-TO: Convert WebP Image to GIF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\sample.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    webp.Save(outputPath, gifOptions);
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
 * 1. When you need to display a WebP picture on a website that only supports GIF format.
 * 2. When you are building a .NET batch process that converts user‑uploaded WebP files to GIF for email attachments.
 * 3. When you must create an animated preview from a WebP sequence and output it as a GIF for compatibility with older browsers.
 * 4. When you want to generate a GIF thumbnail from a high‑quality WebP image while preserving transparency using Aspose.Imaging.
 * 5. When you are migrating a media library from WebP to GIF to meet a client’s legacy system requirements in a C# application.
 */
