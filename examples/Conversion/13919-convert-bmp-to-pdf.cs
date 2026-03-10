using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source BMP file
        string inputPath = "input.bmp";
        // Desired path for the output PDF file
        string outputPath = "output.pdf";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Convert and save the image as PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}