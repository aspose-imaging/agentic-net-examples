using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect the BMP input file path and the PDF output file path as command‑line arguments.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <exe> <input.bmp> <output.pdf>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the BMP image.
        using (Image image = Image.Load(inputPath))
        {
            // Convert and save the image as a PDF, preserving fidelity.
            PdfOptions pdfOptions = new PdfOptions();
            image.Save(outputPath, pdfOptions);
        }
    }
}