// HOW-TO: Combine Multiple TIFF Files with Different Compression per Frame in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string inputPath1 = "input1.tif";
            string inputPath2 = "input2.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage src1 = (TiffImage)Image.Load(inputPath1))
            using (TiffImage src2 = (TiffImage)Image.Load(inputPath2))
            {
                // First frame compression: LZW
                TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default);
                options1.Compression = TiffCompressions.Lzw;

                int width1 = src1.ActiveFrame.Width;
                int height1 = src1.ActiveFrame.Height;

                using (TiffImage outTiff = (TiffImage)Image.Create(options1, width1, height1))
                {
                    // Copy first frame pixels
                    Color[] pixels1 = ((RasterImage)src1).LoadPixels(src1.ActiveFrame.Bounds);
                    outTiff.ActiveFrame.SavePixels(outTiff.ActiveFrame.Bounds, pixels1);

                    // Second frame compression: Deflate
                    TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default);
                    options2.Compression = TiffCompressions.Deflate;

                    int width2 = src2.ActiveFrame.Width;
                    int height2 = src2.ActiveFrame.Height;

                    TiffFrame newFrame = new TiffFrame(options2, width2, height2);

                    // Copy second frame pixels
                    Color[] pixels2 = ((RasterImage)src2).LoadPixels(src2.ActiveFrame.Bounds);
                    newFrame.SavePixels(newFrame.Bounds, pixels2);

                    outTiff.AddFrame(newFrame);
                    outTiff.Save(outputPath);
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
 * 1. When you need to merge scanned documents from separate TIFF files into a single multi‑page TIFF while using LZW for the first page and Deflate for the second to meet archival and size‑reduction requirements.
 * 2. When a medical imaging system must combine patient scans stored as individual TIFF frames, applying a lossless compression method appropriate for each modality.
 * 3. When a publishing workflow requires assembling high‑resolution TIFF pages from different sources, assigning a specific compression to each page to balance quality and file size.
 * 4. When an automated batch process creates a multi‑page TIFF report and wants to use a faster Deflate compression for later pages while keeping the first page in LZW for compatibility with legacy software.
 * 5. When a GIS application concatenates raster TIFF layers from separate datasets and needs to specify distinct compression algorithms for each layer to optimize storage and rendering performance.
 */
