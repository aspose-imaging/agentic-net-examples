// HOW-TO: Deskew CDR Image, Apply Gaussian Blur and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output\\output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.NormalizeAngle(false, Color.LightGray);

                        var blurOptions = new GaussianBlurFilterOptions(5, 1.0f);
                        raster.Filter(raster.Bounds, blurOptions);

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
                    }
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
 * 1. When you need to correct the orientation of a scanned CorelDRAW (CDR) file before applying a softening effect and exporting it as a high‑resolution TIFF for printing.
 * 2. When a workflow requires converting vector CDR artwork to a raster format, deskewing it to remove skew, and then applying a Gaussian blur to create a background image for a brochure.
 * 3. When an automated batch process must take CDR files, straighten them, blur edges for a watermark effect, and store the results as TIFF files for archival in a document management system.
 * 4. When integrating Aspose.Imaging in a C# application to preprocess CDR graphics by normalizing angle, applying a blur filter, and saving the output as TIFF for further analysis in image‑processing pipelines.
 * 5. When a developer wants to generate blurred TIFF previews of CDR designs for web thumbnails while ensuring the original orientation is corrected.
 */
