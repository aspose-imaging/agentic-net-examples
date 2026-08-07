using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.wmf";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF save options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Basic PDF document info (can be extended as needed)
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();

                    // Vector rasterization options to keep original line thickness and colors
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When a developer needs to convert legacy Windows Metafile (WMF) diagrams into PDF reports while preserving the original line thickness and colors.
 * 2. When an engineering application must generate printable PDF schematics from WMF vector drawings without losing visual fidelity for client review.
 * 3. When an automated document pipeline has to batch‑process WMF assets and output PDF files that retain exact stroke widths for compliance documentation.
 * 4. When a C# desktop tool requires exporting WMF icons or flowcharts to PDF for inclusion in marketing brochures while maintaining their original color palette.
 * 5. When a web service needs to transform user‑uploaded WMF files into PDF format on the server using Aspose.Imaging, ensuring that vector line styles remain unchanged.
 */