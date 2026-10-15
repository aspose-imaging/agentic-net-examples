// HOW-TO: Asynchronously Load SVG and Save as PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static async Task Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            byte[] svgBytes = await File.ReadAllBytesAsync(inputPath);
            using var inputStream = new MemoryStream(svgBytes);
            using var svgImage = (SvgImage)Image.Load(inputStream);

            var pngOptions = new PngOptions();

            using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);
            await Task.Run(() => svgImage.Save(outputStream, pngOptions));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API needs to convert user‑uploaded SVG icons to PNG thumbnails without blocking the request thread.
 * 2. When a desktop application must display a progress bar while converting large SVG diagrams to PNG files in the background.
 * 3. When a batch job processes thousands of SVG assets on a server and wants to keep I/O operations non‑blocking to improve throughput.
 * 4. When an automated build pipeline generates PNG previews of SVG assets for documentation and needs asynchronous file handling to speed up the pipeline.
 * 5. When a .NET service streams SVG data from storage, converts it to PNG, and writes the result to a cloud blob store without tying up threads.
 */
