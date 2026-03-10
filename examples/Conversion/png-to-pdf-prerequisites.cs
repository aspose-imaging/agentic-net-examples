using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Prerequisite: a valid PNG file at the specified location
        string inputPath = "input.png";

        // Prerequisite: define the output PDF file path
        string outputPath = "output.pdf";

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Prerequisite: create PdfOptions instance for PDF export
            var pdfOptions = new PdfOptions();

            // Save the image as PDF using the options
            image.Save(outputPath, pdfOptions);
        }
    }
}