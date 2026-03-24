using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the 24‑bit BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF save options (default preserves color fidelity)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}