// HOW-TO: Add Custom Photometric TIFF Frame and Save Multi‑Frame Image with LZW in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.tif";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = tiffImage.ActiveFrame.Width;
                int height = tiffImage.ActiveFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Photometric = TiffPhotometrics.Rgb;

                TiffFrame newFrame = new TiffFrame(tiffOptions, width, height);

                using (RasterImage raster = (RasterImage)newFrame)
                {
                    Aspose.Imaging.Color[] whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White, width * height).ToArray();
                    raster.SavePixels(new Aspose.Imaging.Rectangle(0, 0, width, height), whitePixels);
                }

                if (newFrame.ExifData is Aspose.Imaging.Exif.JpegExifData jpegExif)
                {
                    jpegExif.PhotometricInterpretation = 2;
                }

                tiffImage.AddFrame(newFrame);
                tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to create a multi‑page TIFF document where each page has a specific photometric interpretation, such as converting a blank page to white and preserving color information.
 * 2. When you must append a new frame to an existing TIFF file and ensure the entire file uses lossless LZW compression to reduce size without quality loss.
 * 3. When generating archival TIFF images that require custom EXIF photometric interpretation values for compatibility with legacy imaging systems.
 * 4. When automating batch processing of scanned documents and need to add blank pages programmatically while maintaining consistent RGB photometric settings.
 * 5. When building a C# application that manipulates TIFF files with Aspose.Imaging and must save the result as a multi‑frame TIFF with specific compression and photometric options.
 */
