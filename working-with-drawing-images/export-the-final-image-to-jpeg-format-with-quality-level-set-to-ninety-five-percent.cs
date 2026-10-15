// HOW-TO: Convert PNG to JPEG with 95% Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Quality = 95;
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce the file size of a PNG logo for faster web page loading by converting it to a high‑quality JPEG.
 * 2. When an e‑commerce platform requires product images in JPEG format with a specific quality setting for consistent display across browsers.
 * 3. When a batch processing tool must transform scanned PNG documents into JPEGs while preserving visual fidelity at 95 percent quality.
 * 4. When a mobile app generates screenshots in PNG and you must export them as JPEGs to meet upload size limits without noticeable loss.
 * 5. When integrating Aspose.Imaging into a C# service that prepares user‑uploaded PNG avatars for storage as JPEGs with controlled compression.
 */
