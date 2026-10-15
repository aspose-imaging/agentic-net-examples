// HOW-TO: Increase Contrast of CDR Image and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/enhanced.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                int width = cdrImage.Width;
                int height = cdrImage.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (Image tiffImage = Image.Create(tiffOptions, width, height))
                {
                    Graphics graphics = new Graphics(tiffImage);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(cdrImage, new Rectangle(0, 0, width, height));

                    RasterImage raster = (RasterImage)tiffImage;
                    raster.AdjustContrast(50f);

                    tiffImage.Save();
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
 * 1. When you need to convert a CorelDRAW (.cdr) design to a high‑contrast TIFF for printing or archival purposes.
 * 2. When an application must programmatically enhance the visual clarity of vector artwork before embedding it in a PDF or document workflow.
 * 3. When a batch process has to adjust the contrast of multiple CDR files and store the results as lossless TIFF images for downstream image analysis.
 * 4. When you want to render a CDR drawing onto a white background and increase its contrast to meet publishing guidelines using C#.
 * 5. When integrating Aspose.Imaging into a .NET service that receives CDR uploads and returns contrast‑enhanced TIFF files for web viewers.
 */
