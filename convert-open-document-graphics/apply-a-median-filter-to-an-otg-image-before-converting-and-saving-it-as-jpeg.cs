// HOW-TO: Apply Median Filter to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        vectorImage.Save(ms, pngOptions);
                    }

                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                        using (JpegOptions jpegOptions = new JpegOptions())
                        {
                            raster.Save(outputPath, jpegOptions);
                        }
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
 * 1. When you need to reduce noise in a vector OTG graphic before converting it to a JPEG for web display.
 * 2. When you must rasterize an OTG file, apply a median filter, and save the result as a compressed JPEG for email attachments.
 * 3. When preparing OTG drawings for a mobile app, you can use this code to clean the image and output a JPEG that balances quality and file size.
 * 4. When automating a batch process that converts legacy OTG assets to JPEG thumbnails with built‑in noise reduction using Aspose.Imaging in C#.
 * 5. When integrating image preprocessing into a document workflow, this snippet lets you filter and convert OTG diagrams to JPEGs ready for PDF embedding.
 */
