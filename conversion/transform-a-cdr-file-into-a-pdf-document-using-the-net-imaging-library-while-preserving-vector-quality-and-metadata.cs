using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.cdr";
        // Output PDF file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve original metadata
                KeepMetadata = true,
                // Set vector rasterization options to retain vector quality
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                }
            };

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}