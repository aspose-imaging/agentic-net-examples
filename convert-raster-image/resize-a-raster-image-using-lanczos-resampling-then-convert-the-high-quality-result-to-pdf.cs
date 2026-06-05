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
            string inputPath = @"input.jpg";
            string outputPath = @"output\result.pdf";

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
                // Desired dimensions (example: half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using Lanczos resampling for high quality
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

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