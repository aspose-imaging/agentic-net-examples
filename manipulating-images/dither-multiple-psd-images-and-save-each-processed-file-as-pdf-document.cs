// HOW-TO: Batch Dither PSD Files and Convert Them to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = "input";
            string outputFolder = "output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all PSD files in the input folder
            string[] inputPaths = Directory.GetFiles(inputFolder, "*.psd");

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for dithering
                    if (image is RasterImage rasterImage)
                    {
                        // Apply Floyd‑Steinberg dithering with 256 colors (BitCount = 8)
                        rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    }

                    // Prepare output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to prepare a set of Photoshop PSD designs for printing by applying Floyd‑Steinberg dithering and exporting each as a PDF file using C#.
 * 2. When an automated workflow must reduce the color depth of many PSD assets to 256 colors before archiving them as PDFs for size‑constrained distribution.
 * 3. When a web service processes user‑uploaded PSD files, applies dithering to improve visual quality on low‑color displays, and returns the result as PDF documents.
 * 4. When a desktop application has to convert a folder of layered PSD images into PDF reports while ensuring consistent dithering across all pages.
 * 5. When a batch script needs to guarantee that every PSD in a directory is saved as a PDF with the same dithering settings for compliance with a publishing pipeline.
 */
