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
        string outputPath = @"C:\Images\sample_converted.pdf";

        try
        {
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
                var pdfOptions = new PdfOptions();

                // Set PDF document title metadata
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Converted OTG Document"
                };

                // Configure OTG rasterization options
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size // preserve original size
                };
                pdfOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}