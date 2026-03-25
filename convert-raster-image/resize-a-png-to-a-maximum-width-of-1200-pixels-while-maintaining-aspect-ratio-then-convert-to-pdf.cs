using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            const int maxWidth = 1200;

            // Resize if width exceeds the maximum, preserving aspect ratio
            if (image.Width > maxWidth)
            {
                int newWidth = maxWidth;
                int newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);
                image.Resize(newWidth, newHeight);
            }

            // Save the image as PDF
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}