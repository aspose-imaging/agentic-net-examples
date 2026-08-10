// HOW-TO: Convert CMX to PDF with Subset Font Embedding in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image with default CMX load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Prepare PDF export options
                var pdfOptions = new PdfOptions
                {
                    // Use CMX‑specific rasterization options for vector rendering
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        // Render text as single‑bit per pixel to keep file size low
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        // Disable smoothing for sharper output
                        SmoothingMode = SmoothingMode.None,
                        // Positioning defined by the source document
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Save the image as PDF; fonts are embedded as subsets by default
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as searchable PDFs while keeping file size low by embedding only the used characters of the fonts.
 * 2. When a document management system must automatically convert uploaded CMX files to PDF for consistent viewing across platforms, using C# and Aspose.Imaging.
 * 3. When generating printable PDFs from CMX artwork in a batch process and you want the fonts to be subset‑embedded to ensure the PDF renders correctly on machines without the original fonts.
 * 4. When integrating a C# application that receives CMX graphics from a third‑party tool and must deliver them as PDF reports with vector fidelity and minimal smoothing.
 * 5. When creating a web service that transforms user‑provided CMX images into compact PDF files, leveraging Aspose.Imaging’s rasterization options to control text rendering and font embedding.
 */
