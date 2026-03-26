using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.webp";
        string outputPath = "C:\\temp\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Configure PDF options with A4 page size (595 x 842 points)
            PdfOptions pdfOptions = new PdfOptions
            {
                PageSize = new SizeF(595f, 842f)
            };

            // Save the image as PDF
            webPImage.Save(outputPath, pdfOptions);
        }
    }
}