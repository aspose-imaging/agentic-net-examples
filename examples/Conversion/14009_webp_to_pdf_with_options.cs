using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input WebP file and output PDF file.
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Allow paths to be passed via command‑line arguments.
        if (args.Length >= 2)
        {
            inputPath = args[0];
            outputPath = args[1];
        }

        // Load the WebP image (Aspose.Imaging automatically detects the format).
        using (Image image = Image.Load(inputPath))
        {
            // Create and configure PDF options.
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve original image metadata in the PDF.
                KeepMetadata = true,
                // Use the original image DPI when rendering the PDF page.
                UseOriginalImageResolution = true,
                // Optional: set document information (title, author, etc.).
                PdfDocumentInfo = new PdfDocumentInfo()
            };

            // Save the loaded image as a PDF using the custom options.
            image.Save(outputPath, pdfOptions);
        }
    }
}