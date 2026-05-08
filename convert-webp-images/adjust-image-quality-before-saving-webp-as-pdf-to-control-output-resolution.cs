using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.webp";
            string tempWebPPath = @"C:\Images\temp_quality.webp";
            string outputPdfPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempWebPPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Define WebP options with desired quality (e.g., 75)
            var webpOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 75f
            };

            // Load the original WebP image
            using (Image originalImage = Image.Load(inputPath))
            {
                // Re‑save the image with the specified quality to a temporary WebP file
                originalImage.Save(tempWebPPath, webpOptions);
            }

            // Load the quality‑adjusted WebP image
            using (Image adjustedImage = Image.Load(tempWebPPath))
            {
                // Save the image as PDF (resolution can be controlled via ResolutionSettings if needed)
                var pdfOptions = new PdfOptions
                {
                    // Example: set resolution to 150 DPI
                    ResolutionSettings = new ResolutionSetting(150.0, 150.0)
                };

                adjustedImage.Save(outputPdfPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}