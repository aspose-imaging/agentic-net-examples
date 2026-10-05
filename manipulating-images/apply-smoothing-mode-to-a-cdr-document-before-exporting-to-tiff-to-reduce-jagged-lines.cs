// HOW-TO: Apply Anti-Alias Smoothing to CDR When Converting to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                var rasterOptions = new CdrRasterizationOptions
                {
                    SmoothingMode = SmoothingMode.AntiAlias,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                cdr.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate high‑quality TIFF previews of CorelDRAW (CDR) files for print‑ready PDFs without jagged edges.
 * 2. When an application must batch‑convert CDR artwork to TIFF for archival purposes while preserving smooth vector lines.
 * 3. When a web service creates thumbnail TIFF images from user‑uploaded CDR designs and requires anti‑aliased rendering.
 * 4. When integrating Aspose.Imaging into a C# workflow to export CDR diagrams to TIFF for GIS or CAD systems that need clean raster output.
 * 5. When automating document processing to ensure that converted TIFFs from CDR maintain visual fidelity on high‑resolution monitors.
 */
