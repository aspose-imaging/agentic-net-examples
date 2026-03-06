using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Define input PNG file and output PDF file paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.png");
        string outputPath = Path.Combine(dir, "sample.pdf");

        // Load the PNG image using the Aspose.Imaging Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Optionally, set page size to match the image dimensions
            pdfOptions.PageSize = image.Size;

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("PNG image has been successfully converted to PDF.");
    }
}