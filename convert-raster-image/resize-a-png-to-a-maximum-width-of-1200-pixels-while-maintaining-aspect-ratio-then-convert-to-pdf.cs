using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine new dimensions while preserving aspect ratio
                int maxWidth = 1200;
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (image.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round((double)image.Height * maxWidth / image.Width);
                }

                // Resize if needed
                if (newWidth != image.Width || newHeight != image.Height)
                {
                    image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);
                }

                // Convert to PDF using PdfOptions
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}