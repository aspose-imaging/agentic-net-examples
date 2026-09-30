// HOW-TO: Convert EPS to PDF While Preserving Vector Data in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                // Optional: set PDF compliance if desired
                // pdfOptions.PdfCompliance = PdfComplianceVersion.PdfA1b;
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
 * 1. When a developer needs to embed scalable EPS artwork into a PDF report without rasterizing the graphics.
 * 2. When an application must generate PDF invoices that include vector logos originally stored as EPS files.
 * 3. When a print workflow requires converting EPS designs to PDF for downstream pre‑press processing while keeping them editable.
 * 4. When a web service converts user‑uploaded EPS files to PDF for preview, ensuring the output remains resolution‑independent.
 * 5. When automating batch conversion of EPS illustrations to PDF archives for archival purposes without losing quality.
 */
