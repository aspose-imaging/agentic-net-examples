using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF options and preserve metadata
            var pdfOptions = new PdfOptions
            {
                KeepMetadata = true,
                ExifData = image.ExifData // copy EXIF data from source
            };

            // Save as PDF with preserved EXIF metadata
            image.Save(outputPath, pdfOptions);
        }
    }
}