using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image
        using (var image = (EpsImage)Image.Load(inputPath))
        {
            // Prepare PDF options with custom metadata
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Document Tracking ID: 12345",
                    Author = "MyCompany"
                }
            };

            // Save as PDF with metadata
            image.Save(outputPath, pdfOptions);
        }
    }
}