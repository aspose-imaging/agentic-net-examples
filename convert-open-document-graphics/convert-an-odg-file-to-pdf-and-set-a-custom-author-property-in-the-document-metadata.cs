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
        string inputPath = @"C:\input\sample.odg";
        string outputPath = @"C:\output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
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

            // Configure PDF save options and attach rasterization options
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfDocumentInfo = new PdfDocumentInfo { Author = "Custom Author" }
            };

            // Save the image as PDF with the specified metadata
            image.Save(outputPath, pdfOptions);
        }
    }
}