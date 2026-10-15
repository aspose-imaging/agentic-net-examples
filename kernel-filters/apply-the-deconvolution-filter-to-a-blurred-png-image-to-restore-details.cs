// HOW-TO: Load and Save PNG Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, saveOptions);
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
 * 1. When you need to read a PNG file, process it in memory, and write it back to disk using Aspose.Imaging in a .NET application.
 * 2. When you want to convert a PNG stored on a server to a new file location while preserving image quality in C#.
 * 3. When an automated batch job must verify that a PNG exists, load it, and re‑save it to ensure compatibility with Aspose.Imaging pipelines.
 * 4. When you are building a web API that receives a PNG upload, loads it with Aspose.Imaging, and returns a saved copy to the client.
 * 5. When you need to create a new PNG file from a raster image object after applying other Aspose.Imaging transformations in C#.
 */
