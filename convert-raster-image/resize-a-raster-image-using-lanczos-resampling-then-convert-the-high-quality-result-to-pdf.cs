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
                // Define resize settings with Lanczos resampling
                var resizeSettings = new ImageResizeSettings
                {
                    Mode = ResizeType.LanczosResample
                };

                // Example target size (you can adjust as needed)
                int targetWidth = image.Width * 2;   // double width
                int targetHeight = image.Height * 2; // double height

                // Perform high‑quality resize
                image.Resize(targetWidth, targetHeight, resizeSettings);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the resized image as a PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}