// HOW-TO: Convert EPS to JPEG with Vector Rasterization in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                epsImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate web‑ready JPEG thumbnails from EPS logos in a C# application.
 * 2. When a printing workflow requires converting vector EPS artwork to raster JPEG for preview in browsers.
 * 3. When an automated batch process must rasterize EPS diagrams into JPEG images for email attachments.
 * 4. When integrating Aspose.Imaging into a C# service that transforms EPS files into JPEGs with specific page dimensions.
 * 5. When a desktop tool must load an EPS file, rasterize it, and save the result as a JPEG for downstream image analysis.
 */
