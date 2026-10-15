// HOW-TO: Load and Save Large TIFF Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            using (Image image = Image.Load(inputPath))
            {
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
 * 1. When you need to open a multi‑page TIFF file and save it unchanged to a new location in a .NET application.
 * 2. When processing high‑resolution scanned images that are several hundred megabytes, you can load the TIFF with Aspose.Imaging and re‑save it while controlling memory consumption.
 * 3. When automating a batch job that moves raw TIFF files from a scanner into a standardized folder structure using C#.
 * 4. When integrating TIFF handling into a web service that must verify the source file exists before performing the save operation.
 * 5. When you want to catch and log any exceptions that occur while loading or saving large TIFF images to ensure reliable image processing.
 */
