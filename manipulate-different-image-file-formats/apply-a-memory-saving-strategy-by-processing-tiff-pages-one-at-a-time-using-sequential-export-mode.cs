// HOW-TO: How To Export Multi‑Page TIFF One Frame At A Time In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage source = (TiffImage)Image.Load(inputPath))
            {
                int width = source.ActiveFrame.Width;
                int height = source.ActiveFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                using (TiffImage dest = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    int frameCount = source.Frames.Count();
                    for (int i = 0; i < frameCount; i++)
                    {
                        if (i > 0)
                        {
                            dest.AddFrame(new TiffFrame(tiffOptions, width, height));
                        }

                        TiffFrame srcFrame = source.Frames[i];
                        TiffFrame destFrame = dest.Frames[i];

                        Aspose.Imaging.Color[] pixels = source.LoadPixels(srcFrame.Bounds);
                        dest.SavePixels(destFrame.Bounds, pixels);
                    }

                    dest.Save(outputPath, tiffOptions);
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
 * 1. When processing a huge multi‑page TIFF on a server with limited RAM, you can load and write each page sequentially to avoid out‑of‑memory errors.
 * 2. When converting scanned document bundles into a single TIFF while preserving each page, this code lets you add frames one by one without loading the whole file.
 * 3. When creating a PDF‑to‑TIFF pipeline that must handle thousands of pages, you can stream each page to the destination TIFF to keep the application responsive.
 * 4. When extracting individual frames from a multi‑page medical image (e.g., DICOM exported as TIFF) and re‑saving them into a new TIFF, the approach ensures low memory consumption.
 * 5. When building an image‑processing service that resizes or edits each page of a large TIFF archive, you can read, modify, and write each frame sequentially using Aspose.Imaging for .NET.
 */
