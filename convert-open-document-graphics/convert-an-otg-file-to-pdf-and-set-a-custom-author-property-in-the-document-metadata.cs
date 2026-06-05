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
                // Configure rasterization options for OTG
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Prepare PDF save options and attach rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Set custom author metadata
                var docInfo = new PdfDocumentInfo
                {
                    Author = "Custom Author"
                };
                pdfOptions.PdfDocumentInfo = docInfo;

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