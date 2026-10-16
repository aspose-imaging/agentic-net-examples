// HOW-TO: Convert EPS to PSD with Separate Layers Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (var psdOptions = new PsdOptions())
                {
                    psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    psdOptions.VectorizationOptions = new PsdVectorizationOptions
                    {
                        VectorDataCompositionMode = VectorDataCompositionMode.SeparateLayers
                    };
                    image.Save(outputPath, psdOptions);
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
 * 1. When you need to import a vector EPS logo into Photoshop and keep each element on its own layer for further editing.
 * 2. When an automated workflow must batch‑convert EPS illustrations to PSD files while preserving editability for designers.
 * 3. When a web service generates PSD mockups from EPS assets and requires separate layers to apply filters programmatically.
 * 4. When migrating legacy EPS artwork to a Photoshop‑based pipeline and you must retain layer structure for color adjustments.
 * 5. When creating a C# application that converts client‑supplied EPS files to PSD so artists can continue work without flattening the image.
 */
