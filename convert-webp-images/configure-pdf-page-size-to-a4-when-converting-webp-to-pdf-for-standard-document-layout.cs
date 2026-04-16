using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output paths
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with A4 page size (595x842 points at 72 DPI)
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.PageSize = new SizeF(595f, 842f);
                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}