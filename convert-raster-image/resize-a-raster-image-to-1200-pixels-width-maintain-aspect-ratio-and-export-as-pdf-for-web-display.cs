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
            string inputPath = "input.jpg";
            string outputPath = "output\\resized.pdf";

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
                // Calculate new height to maintain aspect ratio
                int newWidth = 1200;
                int newHeight = (int)(image.Height * (newWidth / (double)image.Width));

                // Resize the image with high quality resampling
                image.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

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