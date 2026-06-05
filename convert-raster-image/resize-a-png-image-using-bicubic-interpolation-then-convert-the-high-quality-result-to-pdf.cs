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
            string inputPath = @"C:\Images\input.png";
            string resizedPath = @"C:\Images\resized.png";
            string outputPdfPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Define new dimensions (example: double the size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using bicubic interpolation (CubicConvolution)
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Save the resized image as PNG (optional intermediate step)
                image.Save(resizedPath, new PngOptions());

                // Convert the high‑quality resized image to PDF
                var pdfOptions = new PdfOptions();
                image.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}