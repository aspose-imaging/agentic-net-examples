using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input WebP file and output PDF file paths
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Initialize PDF options (default settings preserve image fidelity)
            PdfOptions pdfOptions = new PdfOptions();

            // Export the loaded WebP image to a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}