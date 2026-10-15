// HOW-TO: Combine Multiple BMP Files into a Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/combined.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<string> inputPaths = new List<string>
            {
                "Input/image1.bmp",
                "Input/image2.bmp",
                "Input/image3.bmp"
            };

            // Validate first input file
            string firstPath = inputPaths[0];
            if (!File.Exists(firstPath))
            {
                Console.Error.WriteLine($"File not found: {firstPath}");
                return;
            }

            using (BmpImage firstBmp = (BmpImage)Image.Load(firstPath))
            {
                int width = firstBmp.Width;
                int height = firstBmp.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Copy first BMP into the first TIFF frame
                    tiff.SavePixels(tiff.Bounds, ((RasterImage)firstBmp).LoadPixels(firstBmp.Bounds));

                    // Process remaining BMP images
                    for (int i = 1; i < inputPaths.Count; i++)
                    {
                        string path = inputPaths[i];
                        if (!File.Exists(path))
                        {
                            Console.Error.WriteLine($"File not found: {path}");
                            return;
                        }

                        using (BmpImage bmp = (BmpImage)Image.Load(path))
                        {
                            // Add a new frame to the TIFF
                            TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);
                            tiff.AddFrame(newFrame);

                            // Copy BMP pixels into the new frame
                            newFrame.SavePixels(newFrame.Bounds, ((RasterImage)bmp).LoadPixels(bmp.Bounds));
                        }
                    }

                    // Save the multi-page TIFF
                    tiff.Save(outputPath);
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
 * 1. When a developer needs to archive a series of scanned BMP images as a single searchable multi‑page TIFF document for easier storage and distribution.
 * 2. When an application must batch‑process BMP screenshots and bundle them into one TIFF file to reduce file count and simplify file handling.
 * 3. When converting legacy BMP assets from an old system into a modern multi‑page TIFF format for compatibility with document management software.
 * 4. When generating a multi‑page TIFF report that combines separate BMP charts or diagrams into one file for printing or emailing.
 * 5. When creating a TIFF‑based image sequence for medical imaging or GIS applications that require each BMP slice to be stored as a separate frame within a single file.
 */
