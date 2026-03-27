using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options (default compliance)
            var pdfOptions = new PdfOptions();

            // Save as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}