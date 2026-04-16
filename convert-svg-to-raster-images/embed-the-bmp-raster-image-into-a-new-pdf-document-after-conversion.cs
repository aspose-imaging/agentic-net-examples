using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image bmpImage = Image.Load(inputPath))
        {
            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image as a PDF document (the BMP will be embedded as a page)
            bmpImage.Save(outputPath, pdfOptions);
        }
    }
}