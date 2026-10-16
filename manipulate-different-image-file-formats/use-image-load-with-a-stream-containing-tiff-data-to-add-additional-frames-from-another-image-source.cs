// HOW-TO: Load TIFF From Stream And Append PNG Frame Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string tiffInputPath = "input.tif";
            string sourceImagePath = "frame2.png";
            string outputPath = "output/output.tif";

            if (!File.Exists(tiffInputPath))
            {
                Console.Error.WriteLine($"File not found: {tiffInputPath}");
                return;
            }
            if (!File.Exists(sourceImagePath))
            {
                Console.Error.WriteLine($"File not found: {sourceImagePath}");
                return;
            }

            using (FileStream fs = new FileStream(tiffInputPath, FileMode.Open, FileAccess.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                ms.Position = 0;
                using (TiffImage tiffImage = (TiffImage)Image.Load(ms))
                using (RasterImage src = (RasterImage)Image.Load(sourceImagePath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffFrame newFrame = new TiffFrame(tiffOptions, src.Width, src.Height))
                    {
                        ((RasterImage)newFrame).SaveArgb32Pixels(newFrame.Bounds, src.LoadArgb32Pixels(src.Bounds));
                        tiffImage.AddFrame(newFrame);
                    }

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When you need to programmatically add a new page to an existing multi‑page TIFF by loading the original file from a stream and inserting a PNG image as an additional frame.
 * 2. When you want to combine scanned documents (TIFF) with generated graphics (PNG) into a single multipage TIFF without writing intermediate files to disk.
 * 3. When a web service receives TIFF data as a byte array and you must augment it with extra image layers before returning the updated file to the client.
 * 4. When automating archival workflows that require merging separate image assets into a single TIFF for compatibility with legacy imaging systems.
 * 5. When building a desktop application that lets users import extra images into an existing TIFF collection while preserving the original file’s metadata and compression settings.
 */
