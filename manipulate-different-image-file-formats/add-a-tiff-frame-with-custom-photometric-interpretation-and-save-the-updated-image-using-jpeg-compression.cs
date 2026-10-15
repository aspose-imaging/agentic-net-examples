// HOW-TO: Add a TIFF Frame with RGB Photometric and JPEG Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int width = tiff.ActiveFrame.Width;
                int height = tiff.ActiveFrame.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.Compression = TiffCompressions.Jpeg;

                using (TiffFrame newFrame = new TiffFrame(frameOptions, width, height))
                {
                    RasterImage sourceRaster = (RasterImage)tiff.ActiveFrame;
                    var pixels = sourceRaster.LoadPixels(sourceRaster.Bounds);
                    newFrame.SavePixels(newFrame.Bounds, pixels);
                    tiff.AddFrame(newFrame);
                }

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.Photometric = TiffPhotometrics.Rgb;

                tiff.Save(outputPath, saveOptions);
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
 * 1. When you need to create a multi‑page TIFF document and want each new page stored using RGB photometric interpretation with JPEG compression to reduce file size in a C# application.
 * 2. When converting scanned grayscale images to color TIFF frames while applying JPEG compression for faster web delivery using Aspose.Imaging for .NET.
 * 3. When adding a processed image as an additional frame to an existing TIFF file and ensuring the whole file uses JPEG compression to maintain compatibility with imaging software.
 * 4. When building a document archiving system that stores each page as a TIFF frame with RGB color space and JPEG compression to balance quality and storage efficiency.
 * 5. When integrating image processing pipelines that require inserting new frames into TIFF files with specific photometric settings and saving the result with JPEG compression in a .NET environment.
 */
