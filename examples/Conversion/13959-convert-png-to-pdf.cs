using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.png";

        // Output PDF file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Load the PNG image using the generic Image class
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Create PDF export options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the loaded image as a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}