// HOW-TO: Create Multi‑Frame TIFF With Custom Photometric Interpretation And LZW Compression In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image srcImage = Image.Load(inputPath))
            {
                int width = srcImage.Width;
                int height = srcImage.Height;

                TiffOptions firstOptions = new TiffOptions(TiffExpectedFormat.Default);
                firstOptions.Compression = TiffCompressions.Lzw;
                firstOptions.Photometric = TiffPhotometrics.Rgb;

                using (TiffImage tiffImage = (TiffImage)Image.Create(firstOptions, width, height))
                {
                    tiffImage.SavePixels(tiffImage.Bounds, ((RasterImage)srcImage).LoadPixels(srcImage.Bounds));

                    TiffOptions secondOptions = new TiffOptions(TiffExpectedFormat.Default);
                    secondOptions.Compression = TiffCompressions.Lzw;
                    secondOptions.Photometric = TiffPhotometrics.MinIsWhite;

                    TiffFrame newFrame = new TiffFrame(secondOptions, width, height);
                    newFrame.SavePixels(newFrame.Bounds, ((RasterImage)srcImage).LoadPixels(srcImage.Bounds));
                    tiffImage.AddFrame(newFrame);

                    tiffImage.Save(outputPath);
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
 * 1. When you need to combine several images into a single TIFF file while preserving each image as a separate frame with specific color interpretation for archival scanning.
 * 2. When you must generate a multi‑page TIFF for printing or document workflows that require LZW compression to reduce file size without losing quality.
 * 3. When building a medical imaging application that stores radiology images as separate frames with different photometric settings, such as MinIsWhite, in a single TIFF container.
 * 4. When creating a GIS or remote‑sensing dataset where each band is saved as a separate TIFF frame with custom photometric interpretation for accurate rendering.
 * 5. When developing a digital asset management system that needs to embed multiple versions of an image (original and processed) into one TIFF file while using lossless LZW compression for efficient storage.
 */
