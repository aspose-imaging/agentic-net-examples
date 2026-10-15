// HOW-TO: How To Invert Colors Of A TIFF And Overwrite File In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                var bounds = tiff.Bounds;
                Color[] pixels = tiff.LoadPixels(bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    Color c = pixels[i];
                    pixels[i] = Color.FromArgb(c.A,
                        (byte)(255 - c.R),
                        (byte)(255 - c.G),
                        (byte)(255 - c.B));
                }
                tiff.SavePixels(bounds, pixels);

                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, options);
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
 * 1. When you need to programmatically invert the colors of a scanned TIFF document before storing it in an archival system.
 * 2. When a medical imaging application must apply a negative effect to DICOM‑converted TIFF files and overwrite the original output.
 * 3. When a batch job processes large numbers of TIFF maps, adjusts pixel values, and saves the modified images to a specific folder without creating duplicate files.
 * 4. When a web service receives a TIFF upload, applies a simple color transformation for preview purposes, and writes the result back using Aspose.Imaging with overwrite enabled.
 * 5. When an automated testing suite validates that TIFF image manipulation code correctly writes the altered image to disk, ensuring the file is replaced if it already exists.
 */
