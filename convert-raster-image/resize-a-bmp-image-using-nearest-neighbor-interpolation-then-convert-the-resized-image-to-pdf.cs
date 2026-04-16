using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input BMP file and output PDF file paths (relative)
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/resized.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new dimensions (example: reduce size by half)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using the default NearestNeighbourResample interpolation
            image.Resize(newWidth, newHeight);

            // Save the resized image as PDF
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}