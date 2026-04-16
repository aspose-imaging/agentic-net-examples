using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
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
            const int maxWidth = 2000;
            int newWidth = image.Width;
            int newHeight = image.Height;

            // Resize proportionally if width exceeds the limit
            if (image.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)((long)image.Height * maxWidth / image.Width);
                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);
            }

            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Set page size to match the resized image dimensions
                PageSize = new Size(newWidth, newHeight)
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}