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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

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
                // Calculate a 10% zoom crop (keep 90% of the original size, centered)
                int cropWidth = (int)(image.Width * 0.9);
                int cropHeight = (int)(image.Height * 0.9);
                int offsetX = (image.Width - cropWidth) / 2;
                int offsetY = (image.Height - cropHeight) / 2;

                var cropRect = new Rectangle(offsetX, offsetY, cropWidth, cropHeight);

                // Perform the crop
                image.Crop(cropRect);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the cropped region as a PDF document
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}