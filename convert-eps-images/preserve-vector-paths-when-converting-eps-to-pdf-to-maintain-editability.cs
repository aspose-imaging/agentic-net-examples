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

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image as a vector image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Configure PDF options; PdfCoreOptions can be set to define compliance if needed
            var pdfOptions = new PdfOptions
            {
                PdfCoreOptions = new PdfCoreOptions
                {
                    // Example compliance setting; adjust as required
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                }
            };

            // Save the EPS as a PDF while preserving vector data
            image.Save(outputPath, pdfOptions);
        }
    }
}