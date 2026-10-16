// HOW-TO: Convert WMF to Progressive JPEG with Quality 90 in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.wmf");
            string outputPath = Path.Combine("Output", "output.jpg");

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
                    jpegOptions.CompressionType = JpegCompressionMode.Progressive;
                    jpegOptions.Quality = 90;
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
 * 1. When you need to display vector WMF graphics on a website and want faster incremental loading, you convert them to progressive JPEGs using C#.
 * 2. When migrating legacy WMF assets to a modern image pipeline, you can batch‑convert them to high‑quality progressive JPEGs for better browser compatibility.
 * 3. When generating thumbnails for email newsletters, converting WMF logos to progressive JPEG reduces download size while preserving visual fidelity.
 * 4. When building a server‑side image service that serves images over slow connections, using progressive JPEG encoding lets browsers render the image progressively.
 * 5. When integrating Aspose.Imaging into a .NET application to automate image format conversion with specific compression settings, this code demonstrates loading a WMF and saving it as a progressive JPEG.
 */
