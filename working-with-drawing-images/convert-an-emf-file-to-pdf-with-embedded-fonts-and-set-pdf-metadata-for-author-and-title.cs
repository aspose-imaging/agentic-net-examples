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
        string inputPath = "input.emf";
        string outputPath = "output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure vector rasterization options for EMF rendering
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            // Set PDF options with embedded fonts and metadata
            var pdfOptions = new PdfOptions
            {
                VectorRasterizationOptions = vectorOptions,
                PdfDocumentInfo = new PdfDocumentInfo
                {
                    Author = "Author Name",
                    Title = "Document Title"
                }
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}