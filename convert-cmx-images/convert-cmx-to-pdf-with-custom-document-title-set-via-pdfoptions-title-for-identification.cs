using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with custom title
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo { Title = "Custom Document Title" };

                    // Set vector rasterization options for proper CMX rendering
                    pdfOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a CAD department needs to archive legacy CMX drawings as searchable PDFs with a custom document title for easy identification in document management systems.
 * 2. When an engineering web service converts user‑uploaded CMX files to PDF on the fly, embedding a specific title so the resulting PDFs can be sorted and displayed correctly in a portal.
 * 3. When a batch‑processing job migrates a library of CMX schematics to PDF while preserving vector fidelity and setting a consistent title for compliance reporting.
 * 4. When a desktop application allows designers to export their CMX artwork to PDF and automatically adds a project‑specific title to meet client branding guidelines.
 * 5. When an automated workflow generates PDF reports from CMX images and includes a custom title to link each PDF back to its source file in a tracking database.
 */