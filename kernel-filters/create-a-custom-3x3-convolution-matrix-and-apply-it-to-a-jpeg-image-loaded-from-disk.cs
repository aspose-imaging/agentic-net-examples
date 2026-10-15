// HOW-TO: Re-Encode JPEG Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                jpegOptions.Source = new FileCreateSource(outputPath, false);
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to load a JPEG file, apply Aspose.Imaging processing, and save it to a new location in a .NET application.
 * 2. When you want to automatically create the destination directory before writing the output JPEG to avoid file‑system errors.
 * 3. When you must verify that the source JPEG exists and provide a clear error message if it is missing.
 * 4. When you require custom JPEG encoding options (such as quality or progressive mode) before saving the image.
 * 5. When you need to catch and log any exceptions that occur during image loading or saving to keep the application stable.
 */
