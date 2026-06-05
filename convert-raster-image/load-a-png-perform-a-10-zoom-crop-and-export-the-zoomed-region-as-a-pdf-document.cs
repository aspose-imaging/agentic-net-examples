using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
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
                // Calculate 10% zoom crop (crop to 90% of original size, centered)
                int cropWidth = (int)(image.Width * 0.9);
                int cropHeight = (int)(image.Height * 0.9);
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);

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