using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file path
        string inputPath = "input.gif";
        // Output PDF file path
        string outputPath = "output.pdf";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Set up PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the GIF as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}