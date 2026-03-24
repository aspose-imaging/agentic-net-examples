using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare PDF export options
        PdfOptions pdfOptions = new PdfOptions
        {
            // Preserve original metadata in the PDF
            KeepMetadata = true,
            // No specific multipage options – export all pages
            MultiPageOptions = null
        };

        // Configure vector rasterization to keep vector quality
        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
        {
            TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
            SmoothingMode = Aspose.Imaging.SmoothingMode.None
        };

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // If the loaded image is a vector image, set page size based on the source dimensions
            if (image is VectorImage)
            {
                rasterOptions.PageWidth = image.Width;
                rasterOptions.PageHeight = image.Height;
            }

            pdfOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as PDF preserving vector data and metadata
            image.Save(outputPath, pdfOptions);
        }
    }
}