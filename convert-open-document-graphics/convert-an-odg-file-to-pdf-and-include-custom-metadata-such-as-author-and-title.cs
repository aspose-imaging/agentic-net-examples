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
        string inputPath = @"C:\Data\sample.odg";
        string outputPath = @"C:\Data\sample.pdf";

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
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options and attach custom metadata
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "John Doe",
                    Title = "Sample ODG to PDF"
                }
            };

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}