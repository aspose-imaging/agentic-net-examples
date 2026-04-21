using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options with PDF version 1.7 compatibility
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // PdfComplianceVersion.Pdf15 corresponds to PDF 1.5;
                    // setting this is the closest available option for PDF 1.7 compatibility.
                    PdfCompliance = PdfComplianceVersion.Pdf15
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}