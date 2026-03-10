using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input JPEG and output PDF file paths
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        string inputPath = Path.Combine(directory, "input.jpg");
        string outputPath = Path.Combine(directory, "output.pdf");

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}