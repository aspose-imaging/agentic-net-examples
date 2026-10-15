// HOW-TO: Resize EPS to 1024x768 and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1024, 768);

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a vector EPS logo to a fixed‑size raster TIFF for printing on a 1024×768 layout.
 * 2. When a web service must generate thumbnail‑size TIFF previews from uploaded EPS files in a .NET application.
 * 3. When an automated batch job has to downscale EPS artwork to a specific resolution before archiving it as a lossless TIFF.
 * 4. When integrating legacy EPS diagrams into a document workflow that only accepts TIFF images at 1024×768 pixels.
 * 5. When creating GIS map tiles that require EPS source maps resized and saved as TIFF files for further analysis.
 */
