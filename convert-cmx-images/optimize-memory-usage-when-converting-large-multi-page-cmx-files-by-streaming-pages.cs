using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.cmx";
        string outputPath = "Output\\sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Release each page after it is saved to reduce memory usage
                cmx.PageExportingAction = delegate (int index, Image page)
                {
                    GC.Collect();
                };

                // Configure PDF options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Save the CMX as a PDF using streaming to handle large multi‑page files efficiently
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
 * 1. When converting a massive multi‑page CMX drawing to PDF in a C# application while keeping memory consumption low by streaming each page.
 * 2. When a CAD‑to‑PDF batch job must process large CMX files on a server with limited RAM and needs automatic page‑wise garbage collection.
 * 3. When integrating Aspose.Imaging into an automated document workflow that requires preserving vector quality and page dimensions during CMX to PDF conversion.
 * 4. When a desktop utility needs to export multi‑page CMX schematics to PDF with a white background and no smoothing to reduce file size and processing overhead.
 * 5. When a .NET service must validate the existence of input CMX files, create output directories, and safely handle exceptions while converting them to PDF using vector rasterization options.
 */