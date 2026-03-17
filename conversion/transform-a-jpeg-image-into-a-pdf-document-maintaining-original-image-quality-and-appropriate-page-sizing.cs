using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";
        // Output PDF file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF options with page size matching the image dimensions
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Set page size to the image size (width, height)
                pdfOptions.PageSize = new Size(image.Width, image.Height);
                // Preserve original image DPI resolution
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}