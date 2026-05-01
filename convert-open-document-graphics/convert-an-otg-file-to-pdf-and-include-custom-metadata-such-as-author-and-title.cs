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
            string inputPath = @"C:\Data\sample.otg";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
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
                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Set custom PDF metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Custom Author",
                    Title = "Custom Title"
                };

                // Configure OTG rasterization options
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original size
                };
                pdfOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save the image as PDF with metadata
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}