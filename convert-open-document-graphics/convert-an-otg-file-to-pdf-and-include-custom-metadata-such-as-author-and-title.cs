using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.otg";
            string outputPath = @"C:\output\sample.pdf";

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
                // Configure PDF options with custom metadata
                PdfOptions pdfOptions = new PdfOptions();
                PdfDocumentInfo docInfo = new PdfDocumentInfo
                {
                    Author = "John Doe",
                    Title = "Sample OTG to PDF"
                };
                pdfOptions.PdfDocumentInfo = docInfo;

                // Set rasterization options for OTG conversion
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original size
                };
                pdfOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}