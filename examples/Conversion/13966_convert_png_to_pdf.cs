using System;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input PNG and output PDF file paths
        string dir = @"C:\temp\";
        string inputPath = System.IO.Path.Combine(dir, "sample.png");
        string outputPath = System.IO.Path.Combine(dir, "sample.pdf");

        // Load the PNG image from the file system using the PngImage constructor
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Save the loaded image as a PDF document using PdfOptions
            pngImage.Save(outputPath, new PdfOptions());
        }
    }
}