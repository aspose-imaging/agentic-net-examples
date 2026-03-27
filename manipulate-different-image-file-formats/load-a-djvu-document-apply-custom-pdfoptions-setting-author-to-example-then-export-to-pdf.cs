using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DjVu document
        using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
        {
            // Configure PDF options with custom author metadata
            var pdfOptions = new PdfOptions
            {
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Example"
                }
            };

            // Export the DjVu document to PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}