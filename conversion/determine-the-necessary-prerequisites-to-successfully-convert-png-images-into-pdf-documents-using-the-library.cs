using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input PNG file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Example: set PDF/A‑1b compliance (optional)
                // PdfCoreOptions = new Aspose.Imaging.FileFormats.Pdf.PdfCoreOptions
                // {
                //     PdfCompliance = Aspose.Imaging.FileFormats.Pdf.PdfComplianceVersion.PdfA1b
                // }
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}