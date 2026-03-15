using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source TIFF file
        string inputPath = "input.tif";
        // Desired path for the output PDF file
        string outputPath = "output.pdf";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Convert and save the image as PDF
            image.Save(outputPath, new PdfOptions());
        }
    }
}