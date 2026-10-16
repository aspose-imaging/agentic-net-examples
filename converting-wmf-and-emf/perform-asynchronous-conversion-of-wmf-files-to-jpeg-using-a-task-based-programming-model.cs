// HOW-TO: Asynchronously Convert WMF to JPEG Using Task in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string? outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            await ConvertWmfToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Task ConvertWmfToJpegAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process legacy WMF graphics into JPEGs without blocking the UI thread in a C# desktop application.
 * 2. When a server‑side service must convert uploaded WMF files to JPEG format asynchronously to improve throughput.
 * 3. When integrating a document conversion pipeline that receives WMF assets and stores them as JPEGs for web display.
 * 4. When automating image preparation for email newsletters, converting WMF logos to JPEGs in a background task.
 * 5. When building a cloud function that transforms WMF icons to JPEG thumbnails while handling file‑system checks and error logging.
 */
