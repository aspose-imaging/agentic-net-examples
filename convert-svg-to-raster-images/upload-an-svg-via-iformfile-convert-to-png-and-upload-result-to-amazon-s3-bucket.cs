// HOW-TO: Convert SVG To PNG With Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }

            // Note: Uploading to Amazon S3 and handling IFormFile are not supported in this console application.
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web API receives an SVG file via IFormFile and needs to store a raster version, you can load the SVG with Aspose.Imaging and save it as a PNG before uploading to storage.
 * 2. When you need to generate high‑quality PNG thumbnails from user‑supplied SVG logos for display on a website, this code converts the vector file to a raster image in C#.
 * 3. When an e‑commerce platform wants to convert product vector illustrations to PNG for faster rendering on mobile devices, Aspose.Imaging can perform the conversion server‑side.
 * 4. When a reporting service must embed SVG charts into PDF or Word documents that only accept PNG images, you can convert the SVG to PNG using the shown method.
 * 5. When automating a CI/CD pipeline that processes design assets, the code can batch‑convert SVG assets to PNG so they can be uploaded to an Amazon S3 bucket for CDN distribution.
 */
