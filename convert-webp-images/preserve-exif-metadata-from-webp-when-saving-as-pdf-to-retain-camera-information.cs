using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Metadata;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.pdf";

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

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Prepare PDF options and preserve metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    KeepMetadata = true
                };

                // Copy EXIF data from the WebP image to PDF options, if present
                if (webPImage.Metadata is ImageMetadata imgMeta && imgMeta.ExifData != null)
                {
                    pdfOptions.ExifData = imgMeta.ExifData;
                }

                // Save as PDF with preserved EXIF metadata
                webPImage.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}