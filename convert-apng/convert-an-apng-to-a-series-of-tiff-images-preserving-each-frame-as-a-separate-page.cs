// HOW-TO: Convert APNG to Multi-Page TIFF with Separate Frames in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.apng";
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

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                if (apng.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the APNG.");
                    return;
                }

                RasterImage firstFrame = (RasterImage)apng.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    tiff.SavePixels(tiff.ActiveFrame.Bounds, firstFrame.LoadPixels(firstFrame.Bounds));

                    for (int i = 1; i < apng.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)apng.Pages[i];
                        tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                        tiff.ActiveFrame = tiff.Frames[i];
                        tiff.SavePixels(tiff.ActiveFrame.Bounds, frame.LoadPixels(frame.Bounds));
                    }

                    tiff.Save();
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
 * 1. When you need to extract each animation frame from an APNG and store them as pages in a single TIFF document for archival or printing.
 * 2. When a web service receives animated PNGs and must deliver a multi-page TIFF to a legacy system that only supports TIFF.
 * 3. When generating a PDF from images and you first convert an APNG into a multi-page TIFF to simplify PDF creation.
 * 4. When creating a contact sheet or slideshow where each frame of an APNG should appear as a separate page in a TIFF for easy viewing in standard image viewers.
 * 5. When performing batch processing of animated graphics and need to convert them to TIFF for compatibility with image analysis tools that require single-file multi-frame inputs.
 */
