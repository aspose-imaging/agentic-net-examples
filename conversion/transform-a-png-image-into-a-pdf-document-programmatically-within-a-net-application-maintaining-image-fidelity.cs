using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image and save it as a PDF
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options (default settings)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the image to PDF format
            image.Save(outputPath, pdfOptions);
        }
    }
}