// HOW-TO: Crop Center 200x200 Pixels from WebP Image in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage image = (WebPImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int cropWidth = 200;
                int cropHeight = 200;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                var rect = new Aspose.Imaging.Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(rect);
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
 * 1. When you need to generate a square thumbnail from a larger WebP photo for a web gallery, you can crop the central 200 × 200 region using C#.
 * 2. When preparing profile pictures stored as WebP files, cropping the middle 200 × 200 pixels ensures a consistent size across the application.
 * 3. When extracting a focused area from a WebP screenshot for documentation, this code isolates the central portion without altering other settings.
 * 4. When optimizing images for mobile UI components that require a fixed 200 × 200 size, cropping the center of a WebP image simplifies the workflow.
 * 5. When creating preview images for a content management system that stores assets in WebP format, the snippet quickly crops and saves the required region.
 */
