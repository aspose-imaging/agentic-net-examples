// HOW-TO: Convert ODG to Progressive JPEG for Faster Web Loading in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive
                };
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
 * 1. When you need to display OpenDocument graphics on a website, converting ODG files to progressive JPEG reduces load time for browsers.
 * 2. When automating a batch process that extracts drawings from LibreOffice files and serves them as web‑optimized images, you can use Aspose.Imaging in C# to perform the conversion.
 * 3. When a content management system stores diagrams as ODG but must deliver them as JPEG thumbnails, progressive encoding ensures quick preview rendering.
 * 4. When building a .NET application that generates reports containing ODG charts, converting them to progressive JPEG allows the reports to be viewed on low‑bandwidth connections.
 * 5. When migrating legacy design assets from OpenDocument format to a universally supported image format, using C# to save them as progressive JPEG simplifies compatibility across browsers and devices.
 */
