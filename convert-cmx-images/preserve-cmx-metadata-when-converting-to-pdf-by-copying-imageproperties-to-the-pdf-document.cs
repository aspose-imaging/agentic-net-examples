// HOW-TO: Convert CMX to PDF while Keeping All Metadata in C# (Aspose.Imaging for .NET)
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
        try
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

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Prepare PDF options and preserve metadata
                var pdfOptions = new PdfOptions
                {
                    KeepMetadata = true,
                    ExifData = cmx.ExifData,
                    XmpData = cmx.XmpData,
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height
                    }
                };

                // Save as PDF with metadata retained
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
 * 1. When a CAD workflow requires exporting CorelDRAW CMX drawings to PDF for client review without losing embedded EXIF or XMP metadata.
 * 2. When an automated document processing system must batch‑convert CMX files to searchable PDFs while preserving original image properties for compliance auditing.
 * 3. When a web service generates PDF reports from CMX graphics and needs to retain color profiles and other metadata for accurate printing.
 * 4. When migrating legacy design assets stored as CMX into a PDF archive and the original metadata must remain intact for asset management.
 * 5. When integrating Aspose.Imaging into a C# application that converts vector CMX files to PDF and must keep background color and page dimensions consistent with the source.
 */
