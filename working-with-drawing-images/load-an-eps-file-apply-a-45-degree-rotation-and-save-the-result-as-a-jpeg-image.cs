// HOW-TO: Rotate EPS Image 45 Degrees and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.eps";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                image.Rotate(45f);

                var jpegOptions = new JpegOptions();
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                jpegOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When you need to display a vector EPS logo at a specific angle on a web page, you can rotate it 45° and convert it to a JPEG for browser compatibility.
 * 2. When preparing print‑ready assets that must be previewed as raster images, rotating the EPS artwork and saving it as JPEG allows quick visual checks in C# applications.
 * 3. When automating a workflow that ingests EPS diagrams and generates thumbnail previews with a consistent orientation, this code rotates the diagram and outputs a JPEG thumbnail.
 * 4. When integrating legacy EPS files into a photo gallery that only supports JPEG, applying a 45‑degree rotation ensures the images align with the gallery’s layout before saving.
 * 5. When creating batch processing tools that standardize the orientation of EPS illustrations for machine‑learning training data, rotating and converting them to JPEG simplifies the dataset preparation.
 */
