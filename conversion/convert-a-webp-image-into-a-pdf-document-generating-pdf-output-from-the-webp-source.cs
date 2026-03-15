using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input WebP file and output PDF file paths.
        string inputPath = "input.webp";
        string outputPath = "output.pdf";

        // Load the WebP image.
        using (Image image = Image.Load(inputPath))
        {
            // Save the loaded image as a PDF document.
            image.Save(outputPath, new PdfOptions());
        }
    }
}