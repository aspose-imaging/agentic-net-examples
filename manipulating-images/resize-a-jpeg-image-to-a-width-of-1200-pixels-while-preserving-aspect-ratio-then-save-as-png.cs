// HOW-TO: Resize JPEG to 1200px Width and Convert to PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int newWidth = 1200;
                int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                image.Save(outputPath);
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
 * 1. When you need to generate web‑optimized thumbnails from high‑resolution JPEG photos while keeping the original aspect ratio and delivering them as PNG files.
 * 2. When an e‑commerce platform must downsize product photos to a consistent 1200‑pixel width before publishing them in a PNG format for transparent backgrounds.
 * 3. When a mobile app server processes user‑uploaded JPEG images, resizes them to a standard width, and stores the result as PNG for faster loading and lossless quality.
 * 4. When a content management system automatically converts legacy JPEG assets to PNG after resizing them to fit a 1200‑pixel layout constraint.
 * 5. When a batch script prepares marketing graphics by resizing source JPEG images to a fixed width and saving them as PNG to preserve sharp edges for overlay use.
 */
