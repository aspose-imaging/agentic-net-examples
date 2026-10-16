// HOW-TO: Apply Emboss 5x5 Convolution Filter to JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] emboss5x5 = new double[,]
                {
                    { -2, -1, 0, 1, 2 },
                    { -1, 0, 1, 2, 1 },
                    { 0, 1, 2, 1, 0 },
                    { 1, 2, 1, 0, -1 },
                    { 2, 1, 0, -1, -2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(emboss5x5);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath);
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
 * 1. When you need to enhance edge details of portrait photos before running a face detection algorithm using Aspose.Imaging in C#.
 * 2. When you want to create a stylized embossed effect for product images stored as JPEGs in a .NET web service.
 * 3. When preprocessing scanned documents to highlight texture before OCR by applying a 5x5 convolution filter with Aspose.Imaging.
 * 4. When generating thumbnails with a depth‑enhancing emboss filter for a photo gallery application written in C#.
 * 5. When batch‑processing images to improve visual contrast for machine‑learning training data using the Aspose.Imaging Filter API.
 */
