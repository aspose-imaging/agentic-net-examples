// HOW-TO: Save PNG Image With Aspose.Imaging In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to load an existing PNG file, optionally modify it, and reliably save it back to disk using Aspose.Imaging in a C# application.
 * 2. When your .NET service must generate PNG thumbnails from user‑uploaded images while ensuring the output is created with Aspose.Imaging’s PNG options.
 * 3. When you want to programmatically copy or re‑encode a PNG image to a new location without losing quality in a Windows desktop tool.
 * 4. When an automated batch process has to verify that a PNG file exists, create the output folder if needed, and write the image using Aspose.Imaging’s file source handling.
 * 5. When integrating Aspose.Imaging into a CI pipeline to validate that PNG assets can be opened and saved without errors before deployment.
 */
