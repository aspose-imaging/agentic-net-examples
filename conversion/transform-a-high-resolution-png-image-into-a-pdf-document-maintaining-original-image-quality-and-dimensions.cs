using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Expect two arguments: input PNG path and output PDF path
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input_png_path> <output_pdf_path>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the high‑resolution PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to preserve original image resolution
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.UseOriginalImageResolution = true;

                // Save the image as a PDF document with the same dimensions and quality
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}