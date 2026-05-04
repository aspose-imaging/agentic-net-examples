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
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options to keep original metadata (including EXIF)
                PdfOptions pdfOptions = new PdfOptions
                {
                    KeepMetadata = true
                };

                // Save the image as PDF while preserving EXIF data
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}