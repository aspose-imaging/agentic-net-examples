using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image with default load options
            var loadOptions = new CmxLoadOptions();
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Save as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a CAD system exports drawings as CMX files and a developer must deliver them as lightweight PDF documents with embedded font subsets for easy viewing in browsers.
 * 2. When an enterprise workflow converts legacy CMX technical illustrations to searchable PDF reports while preserving text rendering quality using Aspose.Imaging in a C# application.
 * 3. When a document management solution needs to batch‑process CMX images into PDF format on a Windows server, ensuring the output PDFs are smaller by embedding only the used glyphs.
 * 4. When a .NET service integrates with a printing pipeline that requires PDF files instead of CMX, and the code must handle missing input files and create the target directory automatically.
 * 5. When a software product offers end‑users the ability to preview CMX drawings in a PDF viewer, using Aspose.Imaging’s CmxLoadOptions and PdfOptions to rasterize vector data and embed fonts efficiently.
 */