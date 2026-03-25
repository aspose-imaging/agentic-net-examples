using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

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
            // Calculate a 10% zoom crop (crop to 90% of original size, centered)
            int cropWidth = (int)(image.Width * 0.9);
            int cropHeight = (int)(image.Height * 0.9);
            int offsetX = (image.Width - cropWidth) / 2;
            int offsetY = (image.Height - cropHeight) / 2;
            var cropRect = new Rectangle(offsetX, offsetY, cropWidth, cropHeight);

            // Save the cropped region as a PDF document
            var pdfOptions = new PdfOptions(); // default PDF options
            image.Save(outputPath, pdfOptions, cropRect);
        }
    }
}