using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\bigimage.tif";
        string outputPath = @"C:\Images\bigimage.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BigTIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PDF export options
            var pdfOptions = new PdfOptions
            {
                // Preserve original image resolution
                UseOriginalImageResolution = true,
                // Keep original metadata if any
                KeepMetadata = true
            };

            // Save the image as PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}