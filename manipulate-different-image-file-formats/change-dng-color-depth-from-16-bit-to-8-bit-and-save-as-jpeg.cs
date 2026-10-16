// HOW-TO: Convert 16‑Bit DNG to 8‑Bit JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        string inputPath = "input.dng";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (DngImage image = (DngImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to display raw camera files on a website, you can convert 16‑bit DNG images to 8‑bit JPEGs using C# and Aspose.Imaging.
 * 2. When a photo‑editing workflow requires smaller files for faster uploads, this code reduces the color depth and saves high‑resolution DNGs as compressed JPEGs.
 * 3. When integrating raw image support into a .NET application, you can load DNG files and export them as standard JPEGs for broad browser compatibility.
 * 4. When preparing raw photos for a printing service that only accepts JPEG, the snippet changes the 16‑bit depth to 8‑bit and changes the format in a single step.
 * 5. When automating batch processing of raw images, you can use this approach to convert each DNG to an 8‑bit JPEG without relying on external command‑line tools.
 */
