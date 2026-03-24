using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.pdf";

        // Verify that the input PNG exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            var pdfOptions = new PdfOptions
            {
                // Preserve original metadata (EXIF, XMP, etc.)
                KeepMetadata = true,
                // Use the original image resolution for the PDF page
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}