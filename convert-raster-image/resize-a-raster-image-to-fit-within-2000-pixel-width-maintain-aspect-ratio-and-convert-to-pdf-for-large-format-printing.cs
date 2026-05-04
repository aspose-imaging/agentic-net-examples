using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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
                // Determine new dimensions to fit within 2000px width while preserving aspect ratio
                int maxWidth = 2000;
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (image.Width > maxWidth)
                {
                    double scale = (double)maxWidth / image.Width;
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round(image.Height * scale);
                }

                // Resize if needed
                if (newWidth != image.Width || newHeight != image.Height)
                {
                    image.Resize(newWidth, newHeight);
                }

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the resized image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}