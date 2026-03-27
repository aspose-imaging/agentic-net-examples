using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PDF options with desired compliance level
        var pdfOptions = new PdfOptions
        {
            PdfCoreOptions = new PdfCoreOptions
            {
                PdfCompliance = PdfComplianceVersion.PdfA1b
            }
        };

        // Load the source image and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, pdfOptions);
        }

        // Validate that the generated PDF can be opened without errors
        try
        {
            using (Image pdfImage = Image.Load(outputPath))
            {
                // If loading succeeds, the PDF is considered valid
                Console.WriteLine("PDF opened successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to open PDF: {ex.Message}");
        }
    }
}