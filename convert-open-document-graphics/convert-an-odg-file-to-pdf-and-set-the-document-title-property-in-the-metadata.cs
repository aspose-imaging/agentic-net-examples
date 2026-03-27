using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image and convert to PDF with title metadata
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = image.Size
            };

            // Configure PDF save options and set document title
            PdfOptions pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = rasterOptions,
                PdfDocumentInfo = new PdfDocumentInfo()
            };
            pdfOptions.PdfDocumentInfo.Title = "Converted ODG Document";

            // Save as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}