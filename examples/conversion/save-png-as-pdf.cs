using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Path to the source PNG file
        string inputPath = @"C:\temp\input.png";

        // Desired path for the resulting PDF file
        string outputPath = @"C:\temp\output.pdf";

        // Load the PNG image using Aspose.Imaging lifecycle method
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // (Optional) Set PDF core options, e.g., compliance level
            // pdfOptions.PdfCoreOptions = new PdfCoreOptions
            // {
            //     PdfCompliance = PdfComplianceVersion.PdfA1b
            // };

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}