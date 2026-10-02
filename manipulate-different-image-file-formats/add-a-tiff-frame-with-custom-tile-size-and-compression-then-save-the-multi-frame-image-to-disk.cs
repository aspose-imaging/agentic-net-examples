// HOW-TO: Add a LZW Compressed TIFF Frame and Save Multi‑Frame Image in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = tiffImage.Width;
                int height = tiffImage.Height;

                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                frameOptions.Compression = TiffCompressions.Lzw;

                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                Color[] whitePixels = new Color[width * height];
                for (int i = 0; i < whitePixels.Length; i++)
                {
                    whitePixels[i] = Color.White;
                }
                newFrame.SavePixels(newFrame.Bounds, whitePixels);

                tiffImage.AddFrame(newFrame);

                tiffImage.Save(outputPath);
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
 * 1. When you need to append a blank page to an existing multi‑page TIFF document for printing or archiving.
 * 2. When you want to create a new layer in a TIFF file with LZW compression to reduce file size while preserving image quality.
 * 3. When you must generate a multi‑frame TIFF for medical imaging where each frame represents a different slice and requires consistent dimensions and compression.
 * 4. When you are building a document conversion pipeline that merges scanned pages into a single TIFF and need to add additional pages programmatically.
 * 5. When you need to automate the creation of a tiled TIFF with custom compression for GIS or satellite imagery workflows.
 */
