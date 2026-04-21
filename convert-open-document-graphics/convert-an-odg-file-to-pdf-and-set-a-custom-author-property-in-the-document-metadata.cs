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
        string inputPath = @"C:\Input\sample.odg";
        string outputPath = @"C:\Output\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG to PDF conversion
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options and set custom author metadata
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Custom Author"
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}