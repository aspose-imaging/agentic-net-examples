using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        // Input directory containing BMP files and output PDF file path
        string inputDirectory = @"C:\Images\BmpInput";
        string outputPdfPath = @"C:\Images\output.pdf";

        // Retrieve all BMP files from the input directory
        string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

        if (bmpFiles.Length == 0)
        {
            Console.WriteLine("No BMP files found in the specified directory.");
            return;
        }

        // Create a multipage image where each BMP file becomes a page
        using (Image multipageImage = Image.Create(bmpFiles))
        {
            // Configure PDF save options
            PdfOptions pdfOptions = new PdfOptions();

            // Optional: set image compression for the PDF pages
            // pdfOptions.Compression = PdfImageCompressionOptions.Flate;

            // Save the multipage image as a PDF document
            multipageImage.Save(outputPdfPath, pdfOptions);
        }

        Console.WriteLine("PDF document created successfully at: " + outputPdfPath);
    }
}