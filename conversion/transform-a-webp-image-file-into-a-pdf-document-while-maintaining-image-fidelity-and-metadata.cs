using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        // Output PDF file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the WebP image (Aspose.Imaging will select the appropriate concrete type)
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to preserve metadata and original resolution
            var pdfOptions = new PdfOptions
            {
                KeepMetadata = true,
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}