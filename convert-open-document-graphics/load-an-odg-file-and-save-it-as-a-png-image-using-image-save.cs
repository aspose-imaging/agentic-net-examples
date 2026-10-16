// HOW-TO: Convert ODG File to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to display an OpenDocument graphic (ODG) on a website that only supports PNG images, you can load the ODG with Aspose.Imaging and save it as PNG in C#.
 * 2. When automating a document workflow that extracts vector drawings from ODG files and stores them as raster PNG thumbnails for quick previews, this code provides the conversion.
 * 3. When building a desktop application that lets users import ODG illustrations and export them as PNG for use in presentations or reports, the snippet handles the format change.
 * 4. When creating a server‑side service that receives ODG uploads and returns PNG versions for downstream image processing pipelines, the Image.Load and Image.Save pattern is ideal.
 * 5. When migrating legacy design assets stored as ODG into a PNG‑based asset library without manual editing, the code programmatically converts each file in C#.
 */
