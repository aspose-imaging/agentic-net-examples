// HOW-TO: Add Semi Transparent Watermark to DNG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (var image = (DngImage)Image.Load(inputPath))
            {
                var graphics = new Graphics(image);
                var font = new Font("Arial", 48);
                var brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255));
                graphics.DrawString("Watermark", font, brush, new Point(50, 50));

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a photographer wants to embed a semi‑transparent copyright notice into raw DNG files using Aspose.Imaging before converting them to PNG for web galleries.
 * 2. When an e‑commerce platform needs to protect product photos by adding a translucent watermark to high‑resolution DNG images and deliver the result as PNG thumbnails via C#.
 * 3. When a mobile app processes user‑uploaded raw images, applies branding text with adjustable opacity using Aspose.Imaging, and saves the output as lossless PNG files.
 * 4. When a digital archiving system converts raw camera DNG files to PNG while marking each image with a faint identifier to deter unauthorized reuse.
 * 5. When a batch script automates the addition of a semi‑transparent logo to DNG files and saves them as PNGs for publishing on social media.
 */
