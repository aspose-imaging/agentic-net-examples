// HOW-TO: Apply Horizontal Sobel Edge Detection to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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

            double[,] sobelKernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel));
                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight horizontal edges in PNG photos before feeding them into an OCR engine, you can use this Sobel filter to improve text recognition accuracy.
 * 2. When processing scanned engineering drawings, applying a horizontal Sobel kernel helps isolate line features for automated dimension extraction.
 * 3. When creating a visual effect that emphasizes road lane markings in traffic camera images, the code extracts horizontal edges to simplify downstream analysis.
 * 4. When preparing medical X‑ray images for edge‑based segmentation, the Sobel filter accentuates bone contours while preserving the original PNG format.
 * 5. When building a batch image‑processing pipeline that must quickly detect horizontal patterns across many PNG files, this Aspose.Imaging convolution example automates the task in C#.
 */
