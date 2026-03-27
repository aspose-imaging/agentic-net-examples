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
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Set PDF document metadata (title)
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
            {
                Title = "Converted OTG Document"
            };

            // Configure vector rasterization for OTG
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size // Preserve original size
            };
            pdfOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}