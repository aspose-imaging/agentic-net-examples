using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.psd";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input PSD file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PSD image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            var pdfOptions = new PdfOptions();

            // Optional: set PDF compliance if required
            // pdfOptions.PdfCoreOptions = new PdfCoreOptions { PdfCompliance = PdfComplianceVersion.PdfA1b };

            // Save the image as a PDF, preserving layers and color fidelity
            image.Save(outputPath, pdfOptions);
        }
    }
}