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
        // Define input and output paths
        string baseDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(baseDir, "Input", "sample.cmx");
        string outputPath = Path.Combine(baseDir, "Output", "sample.pdf");

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
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Prepare PDF options and copy metadata
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.KeepMetadata = true;
                    pdfOptions.ExifData = cmxImage.ExifData;
                    pdfOptions.XmpData = cmxImage.XmpData;

                    // Set vector rasterization options for proper rendering
                    pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    };

                    // Save as PDF preserving metadata
                    cmxImage.Save(outputPath, pdfOptions);
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
 * 1. When an engineering firm needs to archive legacy CorelDRAW CMX drawings as PDF while keeping original EXIF and XMP metadata for regulatory compliance.
 * 2. When a printing service converts customer‑submitted CMX artwork to PDF for proofing and must retain author, creation date, and color profile information embedded in the image properties.
 * 3. When a document management system ingests CMX files and stores them as searchable PDFs, preserving metadata to enable accurate indexing and retrieval.
 * 4. When a CAD/CAM pipeline transforms CMX schematics into PDF manuals and requires the original metadata to be carried over for version tracking and traceability.
 * 5. When a legal department archives CMX‑based technical illustrations as PDFs and needs the embedded metadata to remain intact for evidentiary purposes.
 */