// HOW-TO: Generate 500x500 PNG From MemoryStream With Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output\\generated.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions options = new PngOptions();
                options.Source = new StreamSource(ms);

                using (Image image = Image.Create(options, 500, 500))
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to programmatically generate a 500 × 500 PNG thumbnail from a MemoryStream without loading an existing image file.
 * 2. When you want to create a placeholder PNG in memory for testing Aspose.Imaging image processing pipelines before writing to disk.
 * 3. When you are building a C# web API that returns a dynamically generated 500 × 500 PNG image using StreamSource and ImageOptions.
 * 4. When you need a blank canvas to draw graphics or apply watermarks with Aspose.Imaging and then save it as a PNG file.
 * 5. When you must ensure the output directory exists and automatically save a generated PNG image to a specific folder path.
 */
