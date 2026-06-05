using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPdfPath = @"C:\temp\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define new dimensions (example: half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using nearest‑neighbor interpolation
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the resized image as PDF
                image.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}