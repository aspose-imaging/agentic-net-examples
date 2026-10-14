// HOW-TO: Asynchronously Convert Cmx To Jpeg In C# With Async Await (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
            string inputPath = "input.cmx";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            await ConvertCmxToJpegAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Task ConvertCmxToJpegAsync(string inputPath, string outputPath)
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
 * 1. When a Windows desktop application needs to load a CMX file and save it as a JPEG without freezing the user interface.
 * 2. When a web service processes uploaded CMX images and must generate JPEG thumbnails while keeping the request thread responsive.
 * 3. When a background batch conversion tool runs multiple CMX‑to‑JPEG conversions on separate threads to avoid blocking other operations.
 * 4. When integrating image conversion into an async workflow that reads CMX files from cloud storage and writes JPEGs without blocking I/O.
 * 5. When a photo‑editing app allows users to import Corel Metafile graphics and export them as JPEGs while maintaining a smooth user experience.
 */
