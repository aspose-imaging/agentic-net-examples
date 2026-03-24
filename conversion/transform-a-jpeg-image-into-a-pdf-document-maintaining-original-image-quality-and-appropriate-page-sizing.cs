using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image and save as PDF
        using (Image image = Image.Load(inputPath))
        {
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve original image resolution for quality
                UseOriginalImageResolution = true
            };

            image.Save(outputPath, pdfOptions);
        }
    }
}