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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions();

            // Set document title metadata
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
            {
                Title = "My OTG Document Title"
            };

            // Configure vector rasterization for OTG
            var otgRasterization = new OtgRasterizationOptions
            {
                // Preserve original page size
                PageSize = image.Size
            };
            pdfOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}