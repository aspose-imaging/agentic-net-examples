using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmx = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();

                var rasterOptions = new CmxRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.SizeF(595f, 842f), // A4 size in points
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                cmx.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to use C# and Aspose.Imaging to convert legacy CMX vector drawings into PDF files with exact A4 page size for printing or archiving.
 * 2. When an automated .NET batch process must load CMX images, apply CmxRasterizationOptions (such as SingleBitPerPixel text rendering and no smoothing), and save them as PDF using PdfOptions.
 * 3. When a web API built with C# has to accept CMX uploads, rasterize them with defined positioning, and return A4‑sized PDF documents generated via Aspose.Imaging.Image.Load and Save.
 * 4. When creating a document conversion utility that preserves the original CMX layout by setting PageSize to 595 × 842 points and uses PdfOptions to produce PDF output for compliance systems.
 * 5. When a Windows desktop application requires precise rendering of CMX content—using Aspose.Imaging.SizeF for A4 dimensions and PositioningTypes.DefinedByDocument—before embedding the result in a PDF portfolio.
 */