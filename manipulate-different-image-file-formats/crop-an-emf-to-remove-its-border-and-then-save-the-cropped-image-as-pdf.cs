using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to EmfImage to access cropping functionality
                EmfImage emfImage = (EmfImage)image;

                // Define a margin to remove the border (adjust as needed)
                int margin = 10;

                // Ensure the crop rectangle is within image bounds
                int cropX = margin;
                int cropY = margin;
                int cropWidth = Math.Max(0, emfImage.Width - 2 * margin);
                int cropHeight = Math.Max(0, emfImage.Height - 2 * margin);
                var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                // Crop the image
                emfImage.Crop(cropRect);

                // Save the cropped image as PDF
                var pdfOptions = new PdfOptions();
                emfImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}