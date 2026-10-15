// HOW-TO: Apply Vertical Sobel Edge Detection to JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel));
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
 * 1. When you need to highlight vertical edges in a JPEG photograph before feeding it to a computer‑vision model.
 * 2. When preprocessing scanned documents to enhance text lines for OCR using a Sobel filter in C#.
 * 3. When creating an artistic outline effect for PNG graphics by detecting vertical edges with Aspose.Imaging.
 * 4. When analyzing aerial or satellite images to emphasize road or building edges for GIS applications.
 * 5. When performing quality‑control checks on product images by extracting vertical edge features for defect detection.
 */
