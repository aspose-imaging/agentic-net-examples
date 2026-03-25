using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Desired width
            int targetWidth = 1200;

            // Calculate proportional height
            int targetHeight = (int)Math.Round((double)image.Height * targetWidth / image.Width);

            // Resize while maintaining aspect ratio
            image.Resize(targetWidth, targetHeight, ResizeType.BilinearResample);

            // Prepare PDF export options
            PdfOptions pdfOptions = new PdfOptions();

            // Save the resized image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}