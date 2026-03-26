using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.jpg";
        string outputPath = @"Z:\CloudStorage\Output\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF save options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the image as PDF to the mapped drive location
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}