using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.otg";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure rasterization options for OTG
            OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Set PDF options with custom metadata
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Custom Author",
                    Title = "Custom Title"
                }
            };

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}