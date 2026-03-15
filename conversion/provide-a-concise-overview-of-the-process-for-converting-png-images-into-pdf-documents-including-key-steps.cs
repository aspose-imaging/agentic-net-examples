using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path (default if not provided)
        string inputPath = args.Length > 0 ? args[0] : "sample.png";
        // Output PDF file path (default if not provided)
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the PNG image into an Aspose.Imaging Image object
        using (Image image = Image.Load(inputPath))
        {
            // Initialize PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}