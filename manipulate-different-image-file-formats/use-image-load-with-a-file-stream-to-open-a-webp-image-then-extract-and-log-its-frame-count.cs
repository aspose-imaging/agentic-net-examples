// HOW-TO: Read WebP Image From Stream and Get Frame Count In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(stream))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Loaded image is not a WebP image.");
                    return;
                }

                int frameCount = webp.Pages?.Length ?? 0;
                Console.WriteLine($"Frame count: {frameCount}");
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
 * 1. When you need to verify how many frames an animated WebP file contains before processing it in a C# application.
 * 2. When you want to read a WebP image from a file stream without loading the entire file into memory and log its page count.
 * 3. When building a server‑side image‑validation service that checks uploaded WebP files for animation length using Aspose.Imaging for .NET.
 * 4. When generating a report of WebP assets in a directory and need to record each file’s frame count programmatically.
 * 5. When debugging an image‑conversion pipeline and must ensure the source WebP image’s frame count matches expected values.
 */
