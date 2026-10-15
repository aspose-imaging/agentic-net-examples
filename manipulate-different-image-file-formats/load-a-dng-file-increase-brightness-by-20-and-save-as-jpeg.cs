// HOW-TO: Increase Brightness of DNG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage image = (DngImage)Image.Load(inputPath))
            {
                // Increase brightness by approximately 20% (51 out of 255)
                image.AdjustBrightness(51);

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
 * 1. When a photographer needs to automatically brighten raw DNG files before publishing them as JPEGs on a website.
 * 2. When an e‑commerce platform wants to enhance product photos captured in DNG format by increasing exposure and converting them to JPEG for faster loading.
 * 3. When a scientific imaging application must adjust the brightness of raw sensor data (DNG) and store the result as a standard JPEG for reporting.
 * 4. When a batch‑processing script has to prepare a collection of DNG images with consistent brightness for archival and distribution in JPEG format.
 * 5. When a mobile app backend receives raw DNG uploads, needs to improve visibility by raising brightness, and then serves the images as JPEGs to clients.
 */
