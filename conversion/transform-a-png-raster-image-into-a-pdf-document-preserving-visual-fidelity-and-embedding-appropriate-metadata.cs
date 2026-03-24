using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options and embed metadata
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Title = "Converted PDF",
                    Author = "Aspose.Imaging",
                    Subject = "PNG to PDF conversion",
                    Keywords = "PNG, PDF, conversion"
                }
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}